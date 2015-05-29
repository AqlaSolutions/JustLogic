using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Boolean))]
    public class BooleanDrawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.HorizontalLimited;
            return base.Initialize(args, value, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            GUILayout.Space(15f);
            var value = (Boolean)Value;
            context.BeginLook(false);
            try
            {
                object newValue = EditorGUILayout.Toggle(value, StylesCache.toggle);
                if (!newValue.Equals(value))
                {
                    Value = newValue;
                    return true;
                }
                return false;
            }
            finally { context.EndLook(); }

        }
    }
}