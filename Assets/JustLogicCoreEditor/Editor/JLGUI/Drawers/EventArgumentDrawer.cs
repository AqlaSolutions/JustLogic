using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class EventArgumentDrawer : ParameterDrawerBase
    {
        bool _isEmptyLabel;

        public override ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.HorizontalLimited; } protected set { } }

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            if (!(value is int)) return false;
            var r = base.Initialize(args, value, context);
            if (r)
            {
                _isEmptyLabel = string.IsNullOrEmpty(InitArgs.Label != null ? InitArgs.Label.text : string.Empty);
                Layout = _isEmptyLabel ? ParameterDrawerLayout.HorizontalLimited : ParameterDrawerLayout.VerticalRoot;
                if (_isEmptyLabel)
                    Label = null;
            }
            return r;
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = !_isEmptyLabel;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            int value = (int)Value;
            context.BeginLook(true);
            try
            {
                int newValue;
                if (context.CurrentEditingEvent == null)
                {
                    newValue = _isEmptyLabel
                                  ? EditorGUILayout.IntField(value)
                                  : EditorGUILayout.IntField(Label, value);
                }
                else
                    newValue = EditorGUILayout.Popup(value, 
                        context.CurrentEditingEvent.Arguments
                        .Select(a => a.Key + " (" + a.Value.Name + ")")
                        .ToArray());

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