using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Object))]
    public class ObjectDrawer : AutoHorizontalLayoutedDrawer
    {
        bool _changed;

        protected override bool OnDraw(IDrawContext context)
        {
            Type objType = InitArgs.ExpressionType ?? InitArgs.SupportedType;
            bool changed = _changed;
            _changed = false;
            var obj = (Object)Value;
            var bg = GUI.backgroundColor;
            if (!obj)
                GUI.color = Color.red;
            Object newV = EditorGUILayout.ObjectField(obj, objType, true);
            GUI.color = bg;
            if (!ReferenceEquals(newV, obj))
            {
                Value = newV;
                changed = true;
            }
            if (newV && (typeof(Component).IsAssignableFrom(objType) || (newV is Component) || (newV is GameObject)))
            {
                GenericMenu.MenuFunction2 selectFunc =
                            v =>
                            {
                                if (!ReferenceEquals(v, obj))
                                {
                                    Value = v;
                                    _changed = true;
                                }
                            };
                var go = newV as GameObject;
                if (go == null)
                {
                    var c = newV as Component;
                    if (c) go = c.gameObject;
                }
                if (go)
                {
                    if (GUILayout.Button(new GUIContent("[*]", Value.GetType().Name), StylesCache.label, GUILayout.Width(25f)))
                    {
                        var menu = new GenericMenu();
                        if (objType.IsAssignableFrom(typeof(GameObject)))
                            menu.AddItem(new GUIContent("GameObject"), go == newV, selectFunc, go);
                        foreach (var component in go.GetComponents(objType))
                            menu.AddItem(new GUIContent(component.GetType().Name), component == obj, selectFunc, component);

                        menu.ShowAsContext();
                    }
                }
            }
            return changed;
        }
    }
}