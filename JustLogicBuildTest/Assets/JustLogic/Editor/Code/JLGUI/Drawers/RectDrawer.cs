using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Rect))]
    public class RectDrawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            var value = (Rect)Value;
            context.BeginLook(true);
            try
            {
                object newValue = EditorGUILayout.RectField(value);
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