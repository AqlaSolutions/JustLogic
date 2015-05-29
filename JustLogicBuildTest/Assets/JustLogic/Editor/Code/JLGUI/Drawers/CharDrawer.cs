using System;
using System.Globalization;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(char))]
    public class CharDrawer : AutoHorizontalLayoutedDrawer
    {
        protected override bool OnDraw(IDrawContext context)
        {
            var value = ((char)Value).ToString(CultureInfo.InvariantCulture);
            context.BeginLook(true);
            try
            {
                string newValue = EditorGUILayout.TextField(value);
                if (newValue.Length != 0)
                {
                    if (newValue.Length > 1)
                        newValue = newValue.Remove(0, newValue.Length - 1);

                    if (!newValue.Equals(value))
                    {
                        Value = char.Parse(newValue);
                        return true;
                    }
                }
                return false;
            }
            finally { context.EndLook(); }

        }
    }
}