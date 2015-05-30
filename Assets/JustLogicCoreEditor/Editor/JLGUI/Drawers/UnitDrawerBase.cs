using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public abstract class UnitDrawerBase : ParameterDrawerBase
    {
        bool _selectedMenu;
        bool _drawersCreated;
        bool _changed = false;

        IList<UnitParameter> _parameters = new UnitParameter[0];
        IList<IParameterDrawer> _parameterDrawers = new IParameterDrawer[0];

        TypeInfo _unitType;

        public JLUnitBase Unit
        {
            get { return (JLUnitBase)base.Value; }
            protected set
            {
                if (object.ReferenceEquals(base.Value, value)) return;
                JLScriptableHelper.Destroy(base.Value);
                base.Value = value;
                _unitType = value ? value.GetType() : null;
                _parameters = _unitType != null ? _unitType.JustLogicParametersList : new UnitParameter[0];
            }
        }

        ParameterDrawerLayout _selfLayout = ParameterDrawerLayout.VerticalRoot;
        public override ParameterDrawerLayout SelfLayout { get { return _selfLayout; } protected set { _selfLayout = value; } }

        public override object Value { get { return base.Value; } protected set { Unit = (JLUnitBase)value; } }

        protected override bool Expanded { get { return Unit && Unit.Expanded; } set { if (Unit) Unit.Expanded = value; } }

        public override void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            _drawingTuple = false;
            isTuple = false;
            bool isStart = parentsFromHorizontalStart == 0;
            horizontalChildren = 0;
            var layout = ParameterDrawerLayout.Horizontal;
            var selfLayout = ParameterDrawerLayout.Horizontal;
            if (!_drawersCreated)
            {
                CreateDrawers(context);
                _drawersCreated = true;
            }
            if (_selectedMenu)
            {
                CreateDrawers(context);
                _selectedMenu = false;
                _changed = true;
            }
            if (_unitType != null)
            {
                if (_parameterDrawers.Count > 1)
                    selfLayout = layout = ParameterDrawerLayout.VerticalRoot;
                else if (_parameterDrawers.Count == 1)
                    selfLayout = layout = ParameterDrawerLayout.HorizontalLimited;
                else
                    selfLayout = layout = parentsFromHorizontalStart == 0 ? ParameterDrawerLayout.VerticalRoot : ParameterDrawerLayout.Horizontal;

                if (_parameters.Any(p => IsListType(p.Type)))
                    selfLayout = layout = ParameterDrawerLayout.VerticalRoot;

                //bool becameVerticalFromHorizontal = false;
                bool verticalContainer = selfLayout == ParameterDrawerLayout.VerticalRoot;
                var maxDepthLocal = 0;
                bool isTriple = false;
                foreach (var parameterDrawer in _parameterDrawers)
                {
                    if (parameterDrawer == null)
                        continue;
                    int depth;
                    bool tuple;
                    parameterDrawer.UpdateLayoutType(verticalContainer ? 0 : parentsFromHorizontalStart + 1, context, out horizontalChildren, out depth, out tuple);
                    if (!parameterDrawer.SelfLayout.IsHorizontal() && (horizontalChildren == 0))
                    {
                        //if (layout.IsHorizontal())
                        //  becameVerticalFromHorizontal = true;
                        layout = ParameterDrawerLayout.VerticalRoot;

                        horizontalChildren = 0;
                    }
                    else
                    {
                        if (layout == ParameterDrawerLayout.HorizontalLimited)
                        {
                            //if ((horizontalChildren == 0) && (parentsFromHorizontalStart % 2 == 0))
                            //  horizontalChildren++;
                            horizontalChildren++;
                        }
                        if (_parameterDrawers.Count == 1 && tuple)
                            isTriple = true;
                    }
                    maxDepthLocal = Mathf.Max(depth, maxDepthLocal);
                }
                if (_parameterDrawers.Count != 0)
                    maxDepthLocal++;

                if (layout == ParameterDrawerLayout.HorizontalLimited)
                {
                    int hChildrenOrig = horizontalChildren;
                    if ((horizontalChildren == 1) && (parentsFromHorizontalStart % 2 == 0))
                        horizontalChildren = 2;

                    bool wantsVerticalLayout = (isStart || horizontalChildren % 2 == 0);
                    //bool tupleImpossible = (!isStart || (hChildrenOrig >= 2) || (maxDepthLocal > hChildrenOrig));
                    bool tupleImpossible = isTriple || (maxDepthLocal > hChildrenOrig) || (hChildrenOrig >= 2);
                    if (wantsVerticalLayout)
                    {
                        if (tupleImpossible)
                        {
                            layout = ParameterDrawerLayout.VerticalRoot;
                            //becameVerticalFromHorizontal = true;
                        }
                        else
                        {
                            _drawingTuple = true;
                            isTuple = true;
                        }
                    }
                }
                else horizontalChildren = 0;
                /*if (becameVerticalFromHorizontal && (_parameterDrawers.Count == 1) && (_parameterDrawers[0] != null))
                {
                    int dummy;
                    int md;
                    _parameterDrawers[0].UpdateLayoutType(0, context, out dummy, out md);
                }*/
                if (isTriple) layout = ParameterDrawerLayout.Horizontal;
                maxDepth = maxDepthLocal;
            }
            else maxDepth = 0;
            Layout = layout;
            SelfLayout = selfLayout;
        }

        bool _drawingTuple;

        UnityEngine.Object _assetsContainer;
        static readonly GUIContent TempContent = new GUIContent();

        protected abstract void GetUnits(out IList<TypeInfo> units, out object cacheKey);

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            if (isAppendedToHorizontal)
                GUILayout.Space(15f);
            hasVerticalOutline = (Layout == ParameterDrawerLayout.VerticalRoot) && (_parameters != null) && (_parameters.Count != 0);
            // selector for object subtype
            // if changed Expanded=true
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);

            string unitLabel = _unitType != null ? _unitType.FriendlyName : "<unit not set>";

            IList<TypeInfo> options;
            object cacheKey;
            GetUnits(out options, out cacheKey);
            var changesAllowed = !EditorApplication.isPlaying && (options.Count > 0) && ((options.Count > 1) || (_unitType != options[0]));

            GUIContent content = TempContent;
            content.image = null;
            bool needsResize = !hasVerticalOutline && (isAppendedToHorizontal || _drawingTuple);//((label != null) && !string.IsNullOrEmpty(label.text)));
            if (needsResize && (Screen.width < 700))
            {
                //int chars = Screen.width / 25 + 1;
                //TempContent.text = unitLabel.Length <= chars ? unitLabel : unitLabel.Substring(0, chars).TrimEnd() + "...";
                content.text = unitLabel;
                content.tooltip = unitLabel;
            }
            else
            {
                content.text = unitLabel;
                content.tooltip = InitArgs.SupportedType.FriendlyName;
            }
            // debug
#if DEBUG
            content.tooltip += " (" + Layout + ", s " + SelfLayout + ")";
#endif
            _assetsContainer = JLScriptableHelper.AssetsContainer;
            //var unitClicked = GUILayout.Button(content, changesAllowed ? _unitStyleOn : _unitStyle, GUILayout.ExpandWidth(!isHorizontalLayout));
            var style = changesAllowed ? _unitStyleOn : _unitStyle;
            Rect rect = GUILayoutUtility.GetRect(content, style, GUILayout.ExpandWidth(!Layout.IsHorizontal()));
            if (needsResize)
            {
                rect.width = Mathf.Max(rect.width, style.CalcSize(content).x + 20f);
                var areaWidth = Screen.width - context.OutlinedIndent * 5f;
                if (_drawingTuple)
                    areaWidth = Mathf.Min(areaWidth, PrefixLabelWidth + 35f);
                if (areaWidth < 100f) areaWidth = 100f;

                float checkingWidth = areaWidth;
                if (_drawingTuple)
                    checkingWidth += Mathf.Max(rect.x - context.OutlinedIndent * 5f - 70f, 0f);
                if (checkingWidth < (rect.width + rect.x))
                    rect.width -= (rect.width + rect.x) - checkingWidth;
                int counter = 0;
                while ((style.CalcSize(content).x > rect.width - 15f) && (content.text.Length > 4))
                {
                    counter++;
                    content.text = unitLabel.Remove(unitLabel.Length - counter).TrimEnd() + "...";

                }
            }

            if (JLUnitEditorWindow.CurrentEditingUnit.Drawer == this)
                GUI.DrawTexture(new Rect(rect.x - 5f, rect.y, rect.width + 3f, rect.height), _editingUnitTexture, ScaleMode.StretchToFill);
            if (CanDrag)
            {
                if (Event.current.type == EventType.MouseDrag && rect.Contains(Event.current.mousePosition))
                {
                    DragAndDrop.PrepareStartDrag();
                    DragAndDrop.SetGenericData(typeof(UnitDrawerBase).FullName, this);
                    DragAndDrop.paths = new[] { "///" + typeof(UnitDrawerBase).FullName };
                    DragAndDrop.StartDrag(_unitType != null ? _unitType.FriendlyName : "<unit not set>");
                    Event.current.Use();
                }
            }

            var unitClicked = GUI.Button(rect, content, style);

            if (unitClicked && changesAllowed && (Event.current.button == 0))
            {
                JLUnitEditorWindow.CurrentEditingUnit = new JLUnitEditorWindow.EditingInfo(context.Inspector, options, OnReplace, OnInsert, this);
                context.ScheduleRepaint();
            }

            //ShowUnitSelectionMenu(options, OnMenuSelected, _unitType, "", cacheKey);

            bool advancedMenuClicked = (unitClicked && Event.current.button == 1);
            if (!isAppendedToHorizontal && (!(Layout == ParameterDrawerLayout.Horizontal || Layout == ParameterDrawerLayout.HorizontalLimited) || (_parameters.Count == 0)))
            {
                if (GUILayout.Button(SettingsTexture, StylesCache.label, GUILayout.Width(SettingsTexture.width), GUILayout.Height(SettingsTexture.height)))
                    advancedMenuClicked = true;
            }

            if (advancedMenuClicked)
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Copy"), false, MenuCopyValue);
                if (options.Any(opt => opt.Type == Copier.StoredObjectType))
                    menu.AddItem(new GUIContent("Paste"), false, MenuPasteValue);
                else
                    menu.AddDisabledItem(new GUIContent("Paste"));
                menu.AddItem(new GUIContent("Reset"), false, MenuResetValue);
                if (_unitType != null && _parameters.Count == 1 && InitArgs.ParameterInfo != null)
                {
                    var p = _parameters[0];
                    var v = p.Getter(Value);
                    if (v != null)
                    {
                        TypeInfo type = v.GetType();
                        if (type.IsAssignableTo(InitArgs.ParameterInfo))
                            menu.AddItem(new GUIContent("Replace with value"), false, MenuReplaceWithValue, v);
                    }
                }
                menu.ShowAsContext();
            }

            if ((_unitType == null) && (InitArgs.ParameterInfo != null))
                OnReplace(JLScriptableHelper.GetUnitDefaultSubtype(options, InitArgs.ParameterInfo));
        }

        private void MenuReplaceWithValue(object data)
        {
            UseStoredAssetContainer(() =>
                {
                    var prevValue = Value;
                    _parameters[0].Setter(prevValue, null);
                    JLScriptableHelper.Destroy(prevValue);
                    Value = data;
                });
            _selectedMenu = true;
        }

        private void MenuCopyValue()
        {
            UseStoredAssetContainer(() => Copier.Store(Unit, _unitType));
        }

        private void MenuPasteValue()
        {
            UseStoredAssetContainer(() =>
            {
                var value = Copier.Restore();
                JLScriptableHelper.Destroy(Unit);
                Unit = (JLUnitBase)JLScriptableHelper.WrapUnitIfNeed(value, _unitType.UnitBaseType);
                _selectedMenu = true;
            });
        }

        private void MenuResetValue()
        {
            TypeInfo t = _unitType;
            OnReplace(null);
            OnReplace(t);
        }

        private void OnInsert(TypeInfo newSubtype)
        {
            UseStoredAssetContainer(
                () =>
                {
                    var prevValue = Copier.Duplicate(Value);
                    Unit = (JLUnitBase)JLScriptableHelper.ReplaceUnitSubtype(Unit, InitArgs.SupportedType, newSubtype);
                    newSubtype.JustLogicParameters.ValueParameter.Setter(Unit, prevValue);
                });
            _selectedMenu = true;
            _changed = true;
        }

        private void OnReplace(TypeInfo newSubtype)
        {
            UseStoredAssetContainer(() => Unit = (JLUnitBase)JLScriptableHelper.ReplaceUnitSubtype(Unit, InitArgs.SupportedType, newSubtype));
            _selectedMenu = true;
            _changed = true;
        }

        private void UseStoredAssetContainer(Action action)
        {
            var prev = JLScriptableHelper.AssetsContainer;
            JLScriptableHelper.AssetsContainer = _assetsContainer;
            try
            {
                action();
            }
            finally
            {
                JLScriptableHelper.AssetsContainer = prev;
            }
        }

        static bool _staticInited;

        static Texture2D _editingUnitTexture;
        static Texture2D _settingsTexture;
        public static Texture2D SettingsTexture { get { Initialize(); return _settingsTexture; } }
        static GUIStyle _unitStyle;
        static GUIStyle _unitStyleOn;

        static void Initialize()
        {
            if (!_staticInited || !_settingsTexture || !_editingUnitTexture)
            {
                if (!_settingsTexture)
                    _settingsTexture = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/JustLogic/Icons/Settings.png", typeof(Texture2D));
                if (!_settingsTexture)
                {
                    Debug.LogError("Can't find Assets/JustLogic/Icons/Settings.png");
                    _settingsTexture = new Texture2D(1, 1) { hideFlags = HideFlags.HideAndDontSave };
                }//SimplePopup
                _unitStyle = new GUIStyle(StylesCache.boldLabel) { alignment = TextAnchor.UpperLeft, contentOffset = new Vector2(0f, -5f)};
                _unitStyle.normal.textColor = _unitStyle.onNormal.textColor = Color.gray;
                _unitStyleOn = new GUIStyle(StylesCache.popup);
                _unitStyleOn.normal.textColor = _unitStyleOn.onNormal.textColor = EditorGUIUtility.isProSkin ? Color.white : Color.black;
                if (!_editingUnitTexture)
                {
                    _editingUnitTexture = new Texture2D(1, 1) { hideFlags = HideFlags.HideAndDontSave };
                    var c = Color.blue;
                    c.a = 0.35f;
                    _editingUnitTexture.SetPixels(new[] { c });
                    _editingUnitTexture.Apply();
                }
                _staticInited = true;

            }
        }
        protected UnitDrawerBase()
        {
            Initialize();
        }

        public override void Dispose()
        {
            if (JLUnitEditorWindow.CurrentEditingUnit.Drawer == this)
                JLUnitEditorWindow.CurrentEditingUnit = new JLUnitEditorWindow.EditingInfo();
            DisposeDrawers();
            base.Dispose();
        }

        private void DisposeDrawers()
        {
            foreach (var drawer in _parameterDrawers)
                if (drawer != null)
                    drawer.Dispose();
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = false;
            if (_changed)
            {
                _changed = false;
                changed = true;
            }

            if (Unit)
                for (int i = 0; i < _parameterDrawers.Count; i++)
                {
                    var parameterDrawer = _parameterDrawers[i];
                    var parameter = _parameters[i];

                    if (parameterDrawer.Draw(context))
                    {
                        parameter.Setter(Value, parameterDrawer.Value);
                        changed = true;
                    }
                }

            if (changed)
            {
                context.ScheduleRepaint();
                return true;
            }
            return false;
        }

        bool IsListType(Type type)
        {
            return IsListType(type, InitArgs.Factory);
        }

        public static bool IsListType(Type type, IParameterDrawersFactory factory)
        {
            return type.IsArray;// || (typeof(IList).IsAssignableFrom(type) && !factory.HasDrawers(type));
        }

        private void CreateDrawers(IDrawContext context)
        {
            DisposeDrawers();

            _parameterDrawers = new IParameterDrawer[_parameters.Count];
            for (int i = 0; i < _parameterDrawers.Count; i++)
            {
                var parameter = _parameters[i];
                var value = parameter.Getter(Value);
                var pType = parameter.Type;
                /*if (!IsListType(pType) && (value == null) && !typeof(JLUnitBase).IsAssignableFrom(pType))
                {
                    object newInstance;
                    try
                    {
                        newInstance = Activator.CreateInstance(pType);
                    }
                    catch (Exception e) { Debug.LogError(e); continue; }
                    parameter.Setter(Value, newInstance);
                    _selectedMenu = true;
                }*/
                _parameterDrawers[i] = InitArgs.Factory.CreateDrawer(
                     new DrawerInitArgs(!parameter.IsAutoValue ? (parameter.IsOptional ? "[" + parameter.Name + "]" : parameter.Name) : null,
                         this, pType, InitArgs.Factory, InitArgs.ParameterInfo.Attributes, parameter,
                         containerExpressionType: InitArgs.ExpressionType), value, context);

            }
        }

        public static void ShowUnitSelectionMenu(IList<TypeInfo> options, Action<TypeInfo> setter, TypeInfo selected = null, string unsortedRoot = null, object menuCacheKey = null)
        {
            if (_unitsUsageStats == null)
                _unitsUsageStats = new UnitsUsageStats();

            var menu = new GenericMenu();
            GenericMenu.MenuFunction2 selectFunction =
                x =>
                {
                    var t = (TypeInfo)x;
                    _unitsUsageStats.HandleUsage(t);
                    setter(t);
                };
            if (!string.IsNullOrEmpty(unsortedRoot) && !unsortedRoot.EndsWith("/"))
                unsortedRoot += "/";

            if (selected != null)
                menu.AddItem(new GUIContent(selected.FriendlyName), true, delegate { });

            AddMenuTypeItems(menu, _unitsUsageStats.RecentUsedUnits.Where(options.Contains).ToArray(), selectFunction, 10, "Recent/");
            AddMenuTypeItems(menu, _unitsUsageStats.MostUsedUnits.Where(options.Contains).ToArray(), selectFunction, 10, "Most Used/");

            MenuUnitItem[] menuItems;
            if ((menuCacheKey == null) || !UnitMenuCache.TryGetValue(menuCacheKey, out menuItems))
            {
                var items = new List<MenuUnitItem>();

                foreach (var typeInfo in options)
                {
                    if (typeInfo.UnitMenus.Length != 0)
                        items.AddRange(typeInfo.UnitMenus
                            .Select(unitMenu => new MenuUnitItem(unitMenu, typeInfo == selected, selectFunction, typeInfo)));
                    else if (unsortedRoot != null)
                        items.Add(new MenuUnitItem(unsortedRoot + typeInfo.FriendlyName, false, selectFunction, typeInfo));
                }
                menuItems = items.OrderBy(item => item.Text).ToArray();
                if (menuCacheKey != null)
                    UnitMenuCache.Add(menuCacheKey, menuItems);


                for (int i = 0; i < menuItems.Length; i++)
                    menuItems[i].AddTo(menu);
            }
            else
            {
                for (int i = 0; i < menuItems.Length; i++)
                {
                    var el = menuItems[i];
                    el.Callback = selectFunction;
                    el.On = el.Type == selected;
                    el.AddTo(menu);
                }
            }

            if ((menuItems.Length == 0) && (selected == null))
            {
                setter(null);
                return;
            }


            menu.ShowAsContext();
        }

        static void AddMenuTypeItems(GenericMenu menu, IList<TypeInfo> options, GenericMenu.MenuFunction2 selectFunction, int maxCount, string prefix = "")
        {
            int c = 0;
            foreach (TypeInfo t in options)
            {
                menu.AddItem(new GUIContent(prefix + t.FriendlyName), false, selectFunction, t);
                if (++c >= maxCount) break;
            }
        }

        static UnitsUsageStats _unitsUsageStats;

        static readonly Dictionary<object, MenuUnitItem[]> UnitMenuCache = new Dictionary<object, MenuUnitItem[]>();

        class MenuUnitItem
        {
            public readonly string Text;
            public bool On;
            public GenericMenu.MenuFunction2 Callback;
            public readonly TypeInfo Type;

            public MenuUnitItem(string text, bool @on, GenericMenu.MenuFunction2 callback, TypeInfo type)
            {
                Text = text;
                On = @on;
                Callback = callback;
                Type = type;
            }

            public void AddTo(GenericMenu menu)
            {
                menu.AddItem(new GUIContent(Text), On, Callback, Type);
            }
        }

        bool CanDrag
        {
            get
            {
                if (Unit == null || InitArgs.Container == null) return false;
                Type t = InitArgs.Container.GetType();
                return t == typeof(ArrayDrawer) || t.IsSubclassOf(typeof(ArrayDrawer));
            }
        }
    }
}