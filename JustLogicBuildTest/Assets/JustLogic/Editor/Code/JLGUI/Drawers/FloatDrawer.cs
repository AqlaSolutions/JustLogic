using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(float))]
    public class FloatDrawer : AutoHorizontalLayoutedDrawer
    {
        protected override bool OnDraw(IDrawContext context)
        {
            var value = (float)Value;
            context.BeginLook(true);
            try
            {
                object newValue = EditorGUILayout.FloatField(value);
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