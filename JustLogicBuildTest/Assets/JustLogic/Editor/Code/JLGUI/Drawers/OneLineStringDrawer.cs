using System;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class OneLineStringDrawer : AutoHorizontalLayoutedDrawer
    {
        protected override bool OnDraw(IDrawContext context)
        {
            var value = (String)Value;
            context.BeginLook(true);
            try
            {
                object newValue = EditorGUILayout.TextField(value);
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