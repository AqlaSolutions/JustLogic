using System;
using System.Collections.Generic;
using System.Linq;
using JustLogic.Core;
using JustLogic.Editor;
using JustLogic.Editor.JLGUI.Drawers;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public partial class JLUnitEditorWindow : EditorWindow
{
    #region Structures, operations and properties

    public struct EditingInfo
    {
        private UnitDrawerBase _drawer;
        private IList<TypeInfo> _variants;
        private Action<TypeInfo> _replacer;
        private Action<TypeInfo> _inserter;

        private static readonly TypeInfo[] EmptyTypes = new TypeInfo[0];

        public Editor Inspector { get; private set; }

        public UnitDrawerBase Drawer
        {
            get
            {
                if (!Inspector) return null;
                return _drawer;
            }
            private set { _drawer = value; }
        }

        public IList<TypeInfo> Variants
        {
            get
            {
                if (!Inspector) return EmptyTypes;
                return _variants;
            }
            private set { _variants = value; }
        }

        public Action<TypeInfo> Replacer
        {
            get
            {
                if (!Inspector) return null;
                return _replacer;
            }
            private set { _replacer = value; }
        }

        public Action<TypeInfo> Inserter
        {
            get
            {
                if (!Inspector) return null;
                return _inserter;
            }
            private set { _inserter = value; }
        }

        public EditingInfo(Editor inspector, IList<TypeInfo> variants, Action<TypeInfo> replacer, Action<TypeInfo> inserter, UnitDrawerBase drawer)
            : this()
        {
            Inspector = inspector;
            Variants = variants;
            Replacer = replacer;
            Inserter = inserter;
            Drawer = drawer;
        }
    }

    private static EditingInfo _currentEditingUnit;

    public static EditingInfo CurrentEditingUnit
    {
        get { return _currentEditingUnit; }
        set
        {
            _currentEditingUnit = value;
            var w = GetWindow<JLUnitEditorWindow>();
            if (!w) w = CreateInstance<JLUnitEditorWindow>();
            w.Show();
            w.Focus();
            w.Reset();
            if (w.OpenedCategories.Count == 0 && value.Drawer != null && value.Drawer.Value != null)
                w.OpenMenu(value.Drawer.Value.GetType());
        }
    }

    public void OpenMenu(TypeInfo unitType)
    {
        string menu = unitType.UnitMenus.FirstOrDefault();
        if (menu != null)
            OpenMenu(menu);
    }

    public void OpenMenu(string menu)
    {
        string[] parts = menu.Split('/');
        if (parts.Length <= 1) return;
        string path = null;
        for (int i = 0; i < parts.Length - 1; i++)
        {
            var s = parts[i];
            if (path == null)
                path = s;
            else
                path += "/" + s;
            if (!OpenedCategories.Contains(path))
                OpenedCategories.Add(path);
        }
    }

    private bool SelectedValueIs(Type type)
    {
        if (CurrentEditingUnit.Drawer == null || CurrentEditingUnit.Drawer.Value == null)
            return false;
        var t = CurrentEditingUnit.Drawer.Value.GetType();
        if (t == type) return true;
        if (t == typeof(JLEvaluteBase))
        {
            var exp = ((JLEvaluteBase)CurrentEditingUnit.Drawer.Value).Expression;
            if (exp == null) return false;
            return exp.GetType() == type;
        }
        return false;
    }

    private void AddMenuTypeItems(IList<Unit> menu, IEnumerable<TypeInfo> options, int maxCount, string prefix = "")
    {
        int c = 0;
        foreach (TypeInfo t in options)
        {
            menu.Add(new Unit(prefix + t.FriendlyName, t));
            if (++c >= maxCount) break;
        }
    }

    public List<string> OpenedCategories = new List<string>();

    public Vector2 ScrollPosition;
    public string Filter;

    private static UnitsUsageStats _unitsUsageStats;

    #endregion

    #region Initialization

    private static GUIStyle _btnStyle, _btnSelectedStyle;

    private static bool _isStaticInited;

    private static GUIStyle _foldoutStyle;

    private static GUIStyle _foldoutStyleOn;

    private static void InitializeGUI()
    {
        if (_isStaticInited) return;
        if (_unitsUsageStats == null)
            _unitsUsageStats = new UnitsUsageStats();
        _btnStyle = new GUIStyle(StylesCache.button)
                        {
                            alignment = TextAnchor.MiddleLeft,
                            fixedHeight = 14f,
                            fontSize = 11,
                            margin = new RectOffset(),
                            padding = new RectOffset(10, 0, 0, 0)
                        };
        _btnSelectedStyle = new GUIStyle(_btnStyle);
        _btnSelectedStyle.normal = _btnSelectedStyle.active;

        _foldoutStyle = new GUIStyle(StylesCache.foldout) { fixedWidth = 15f };
        _foldoutStyleOn = new GUIStyle(_foldoutStyle) { normal = _foldoutStyle.onNormal, active = _foldoutStyle.onActive };
        _isStaticInited = true;
    }

    protected void OnEnable()
    {
        title = "JL Select Unit";
        Reset();
    }

    protected void OnDisable()
    {
        CurrentEditingUnit = new EditingInfo();
    }

    UnitEditorCategory _rootReplaceCategory;
    UnitEditorCategory _rootInsertCategory;
    IList<Unit> _allUnitsSorted;
    public bool InsertMode;

    void Reset()
    {
        _rootReplaceCategory = new UnitEditorCategory(string.Empty);

        if (CurrentEditingUnit.Inspector)
        {
            _allUnitsSorted = new List<Unit>();

            if (_unitsUsageStats == null)
                _unitsUsageStats = new UnitsUsageStats();
            AddMenuTypeItems(_allUnitsSorted, _unitsUsageStats.RecentUsedUnits.Where(CurrentEditingUnit.Variants.Contains).ToArray(), 10, "Recent/");
            AddMenuTypeItems(_allUnitsSorted, _unitsUsageStats.MostUsedUnits.Where(CurrentEditingUnit.Variants.Contains).ToArray(), 10, "Most Used/");

            int startCount = _allUnitsSorted.Count;

            foreach (var typeInfo in CurrentEditingUnit.Variants)
            {
                if (typeInfo.UnitMenus.Length != 0)
                {
                    // ReSharper disable once AccessToForEachVariableInClosure
                    foreach (var addItem in typeInfo.UnitMenus.Select(unitMenu => new Unit(unitMenu, typeInfo)))
                        _allUnitsSorted.Add(addItem);
                }
                else _allUnitsSorted.Add(new Unit(typeInfo.FriendlyName, typeInfo));
            }

            _allUnitsSorted = _allUnitsSorted.Take(startCount).Concat(_allUnitsSorted.Skip(startCount).OrderBy(item => item.Path)).ToArray();

            foreach (var item in _allUnitsSorted)
                _rootReplaceCategory.AddUnit(item);

            ReinitializeInsertCategories();
        }
        Repaint();
    }

    void ReinitializeInsertCategories()
    {
        _rootInsertCategory = new UnitEditorCategory(string.Empty);
        foreach (var item in _allUnitsSorted)
        {
            UnitParameters pars = item.Type.JustLogicParameters;
            if (pars != null && pars.ValueParameter != null && ((TypeInfo)CurrentEditingUnit.Drawer.Value.GetType()).IsAssignableTo(pars.ValueParameter))
                _rootInsertCategory.AddUnit(item);
        }
    }

    static void ResetFocus()
    {
        GUI.SetNextControlName("FocusMe()*0ri20jr");
        GUI.Label(new Rect(), "");
        GUI.FocusControl("FocusMe()*0ri20jr");
    }
    #endregion

    protected void OnGUI()
    {
        InitializeGUI();
#if JUSTLOGIC_FREE
        EditorGUILayout.HelpBox("You are using the trial version of JustLogic with limited functionlity.", MessageType.Warning);
#endif
        #region Filter

        GUILayout.BeginHorizontal();
        Filter = EditorGUILayout.TextField("Filter", Filter);
        if (GUILayout.Button("x", GUILayout.Width(19f)))
        {
            Filter = string.Empty;
            ResetFocus();
        }
        GUILayout.EndHorizontal();

        #endregion

        if (!CurrentEditingUnit.Inspector)
        {
            EditorGUILayout.HelpBox("Select unit to edit", MessageType.Info);
            return;
        }

        GUILayout.BeginVertical(StylesCache.box);
        UnitEditorCategory category = InsertMode ? _rootInsertCategory : _rootReplaceCategory;
        var d = InsertMode ? CurrentEditingUnit.Inserter : CurrentEditingUnit.Replacer;
        ScrollPosition = GUILayout.BeginScrollView(ScrollPosition);
        {
            category.Draw(OpenedCategories,
                unit =>
                {

                    if (!CurrentEditingUnit.Inspector) return;
                    var t = unit.Type;
                    _unitsUsageStats.HandleUsage(t);
                    d(t);
                    CurrentEditingUnit.Inspector.Repaint();
                    ReinitializeInsertCategories();
                }, unit => SelectedValueIs(unit.Type), Filter);
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();

        if ((CurrentEditingUnit.Drawer != null) && (CurrentEditingUnit.Drawer.Value != null))
        {
            // TODO download description from web, search link
            GUILayout.BeginVertical(StylesCache.box);
            GUILayout.BeginHorizontal();
            TypeInfo selType = CurrentEditingUnit.Drawer.Value.GetType();
            GUILayout.Label(selType.FriendlyName);
            if (GUILayout.Button("Navigate", GUILayout.Width(110f)))
            {
                OpenedCategories.Clear();
                OpenMenu(selType);
            }
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.Space(15f);
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("Mode: ");
        InsertMode = GUILayout.SelectionGrid(InsertMode ? 1 : 0, new string[] { "Replace", "Insert" }, 2, GUILayout.ExpandWidth(true)) == 1;
        GUILayout.EndHorizontal();
    }
}
