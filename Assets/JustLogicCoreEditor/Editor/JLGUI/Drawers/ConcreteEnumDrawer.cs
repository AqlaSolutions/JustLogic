using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Enum))]
    public class ConcreteEnumDrawer : AutoHorizontalLayoutedDrawer
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            // only subtypes allowed
            if (args.SupportedType == typeof(Enum)) return false;
            return base.Initialize(args, value, context);
        }

        protected override bool OnDraw(IDrawContext context)
        {
            var value = Value;
            if (DrawEnum(ref value, InitArgs.SupportedType))
            {
                Value = value;
                return true;
            }
            return false;
        }

        public static bool DrawEnum(ref object boxedValue, Type type)
        {
            Enum newValue;
            if (Attribute.GetCustomAttribute(type, typeof(FlagsAttribute)) != null)
                newValue = EditorGUILayout.EnumMaskField((Enum)boxedValue, StylesCache.layerMaskField, GUILayout.ExpandWidth(true));
            else
                newValue = (Enum)EditorGUILayout.EnumPopup((Enum)boxedValue, StylesCache.layerMaskField, GUILayout.ExpandWidth(true));

            if (!newValue.Equals(boxedValue))
            {
                boxedValue = newValue;
                return true;
            }
            return false;
        }
    }
}