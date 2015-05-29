using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Vector4))]
    public class Vector4Drawer : ParameterDrawerBase
    {
        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            label = null;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            var value = (Vector4)Value;
            context.BeginLook(true);
            try
            {
                const string autoLabel = "Vector4";
                string label = InitArgs.Label != null ? InitArgs.Label.text : autoLabel;
                if (string.IsNullOrEmpty(label))
                    label = autoLabel;
                object newValue = EditorGUILayout.Vector4Field(label, value);
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