using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(int))]
    [ParameterDrawer(typeof(uint))]
    [ParameterDrawer(typeof(long))]
    [ParameterDrawer(typeof(ulong))]
    [ParameterDrawer(typeof(byte))]
    [ParameterDrawer(typeof(sbyte))]
    [ParameterDrawer(typeof(short))]
    [ParameterDrawer(typeof(ushort))]
    public class IntDrawer : AutoHorizontalLayoutedDrawer
    {
        protected override bool OnDraw(IDrawContext context)
        {
            Type type = InitArgs.SupportedType;
            int value = (int)Convert.ChangeType(Value, TypeCode.Int32);
            context.BeginLook(true);
            try
            {
                object newValue;
                try
                {
                    newValue = Convert.ChangeType(EditorGUILayout.IntField(value), type);
                }
                catch { return false; }

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