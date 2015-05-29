using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(Quaternion))]
    public class QuaternionDrawer : ParameterDrawerBase
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
            var value = (Quaternion)Value;
            context.BeginLook(true);
            try
            {
                const string autoLabel = "Euler Angles";
                string label = InitArgs.Label != null ? InitArgs.Label.text : autoLabel;
                if (string.IsNullOrEmpty(label))
                    label = autoLabel;
                object newValue = Quaternion.Euler(EditorGUILayout.Vector3Field(label, value.eulerAngles));
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