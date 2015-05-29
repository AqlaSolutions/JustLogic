using System;
using System.Collections.Generic;
using System.Linq;
using JustLogic.Core;
using JustLogic.Editor;
using UnityEditor;
using UnityEngine;

partial class JLUnitEditorWindow
{
    class UnitEditorCategory
    {
        private readonly IList<Unit> _units;
        private readonly IDictionary<string, UnitEditorCategory> _subcategories;
        private readonly string _categoryPath;
        private readonly string _categoryName;
        private readonly int _categoryLevel;

        bool CheckMatch(Unit unit, string filter)
        {
            return CheckMatchInternal(unit, filter) || CheckMatchInternal(unit, filter.Replace('.', '/')) || CheckMatchInternal(unit, filter.Replace('/', '.'));
        }

        bool CheckMatchInternal(Unit unit, string filter)
        {
            return filter.Length == 0
                || unit.Path.Replace(" ", "").IndexOf(filter.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) != -1
                || unit.Type.FriendlyName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1
                || unit.Type.FriendlyName.Replace(" ", "").IndexOf(filter.Replace(" ", ""), StringComparison.OrdinalIgnoreCase) != -1
                || unit.Path.IndexOf(TypeInfo.GenerateMemberFriendlyName(filter), StringComparison.OrdinalIgnoreCase) != -1
                || unit.Type.FriendlyName.IndexOf(TypeInfo.GenerateMemberFriendlyName(filter), StringComparison.OrdinalIgnoreCase) != -1
                || unit.Type.Type.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) != -1;
        }

        private bool WillDraw(string filter)
        {
            return _units.Any(unit => CheckMatch(unit, filter)) || _subcategories.Any(s => s.Value.WillDraw(filter));
        }

        public void Draw(IList<string> openedCategories, Action<Unit> onSelected, Func<Unit, bool> checkOn, string filter = "")
        {
            if (filter == null) filter = string.Empty;
            IList<Unit> units = _units.Where(unit => CheckMatch(unit, filter)).ToArray();
            if (_categoryName.Length > 0)
            {
                bool wasOpened = filter.Length != 0 || openedCategories.Contains(_categoryPath);
                bool opened = wasOpened;
                if (GUILayout.Button(
                    new GUIContent(" " + _categoryName, _categoryLevel != 0 ? _categoryPath : String.Empty),
                    opened ? _foldoutStyleOn : _foldoutStyle, GUILayout.ExpandWidth(true)) && filter.Length == 0)
                {
                    opened = !opened;
                }
                if (opened)
                {
                    if (!wasOpened)
                        openedCategories.Add(_categoryPath);
                    EditorGUI.indentLevel++;
                    GUILayout.BeginVertical(StylesCache.box);
                }
                else
                {
                    if (wasOpened)
                        openedCategories.Remove(_categoryPath);
                    return;
                }
            }
            foreach (var subcategory in _subcategories)
            {
                if (subcategory.Value.WillDraw(filter))
                    subcategory.Value.Draw(openedCategories, onSelected, checkOn, filter);
            }
            foreach (var unit in units)
            {
                bool on = checkOn(unit);
                if (DrawUnit(unit, on))
                {
                    onSelected(unit);
                }
            }
            if (_categoryName.Length > 0)
            {
                EditorGUI.indentLevel--;
                GUILayout.EndVertical();
            }
        }

        private static bool DrawUnit(Unit unit, bool on)
        {
            return (GUILayout.Button(new GUIContent(unit.Name, unit.Name != unit.Type.FriendlyName ? unit.Type.FriendlyName : string.Empty),
                    on ? _btnSelectedStyle : _btnStyle) && !on);
        }

        public UnitEditorCategory(string categoryPath)
        {
            _categoryPath = categoryPath;
            _categoryName = categoryPath.Length != 0 ? categoryPath.Split('/').Last() : string.Empty;
            _categoryLevel = _categoryName.Length == 0 ? 0 : categoryPath.Count(c => c == '/') + 1;
            _units = new List<Unit>();
            _subcategories = new Dictionary<string, UnitEditorCategory>();
        }

        public void AddUnit(Unit unit)
        {
            if (unit.CategoryPath == _categoryPath)
                _units.Add(unit);
            else
            {
                UnitEditorCategory subcategory;
                {
                    string subcategoryPath = string.Join("/", unit.CategoryPath.Split('/'), 0, _categoryLevel + 1);
                    if (!_subcategories.TryGetValue(subcategoryPath, out subcategory))
                        _subcategories.Add(subcategoryPath, subcategory = new UnitEditorCategory(subcategoryPath));
                }
                subcategory.AddUnit(unit);
            }
        }
    }
}