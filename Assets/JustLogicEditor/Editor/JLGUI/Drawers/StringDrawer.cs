using System;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(String))]
    public class StringDrawer : ParameterDrawerBase
    {
        public override void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            base.UpdateLayoutType(parentsFromHorizontalStart, context, out horizontalChildren, out maxDepth, out isTuple);
            var value = (string)Value ?? string.Empty;
            bool hasLineEnds = value.Contains("\n");
            bool expanded = _expanded || hasLineEnds;
            Layout = expanded ? ParameterDrawerLayout.VerticalRoot : ParameterDrawerLayout.HorizontalLimited;
        }

        public override ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.HorizontalLimited; } protected set { } }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
            var value = (string)Value ?? string.Empty;
            bool hasLineEnds = value.Contains("\n");
            bool expanded = _expanded || hasLineEnds;
            if (expanded)
            {
                GUILayout.FlexibleSpace();

                context.BeginEnabled(!hasLineEnds);
                if (GUILayout.Button("↑", GUILayout.Width(20f)) && !hasLineEnds)
                    _expanded = false;
                context.EndEnabled();
            }
        }

        bool _expanded;

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            var value = (string)Value ?? string.Empty;
            bool hasLineEnds = value.Contains("\n");
            bool expanded = _expanded || hasLineEnds;

            context.BeginLook(true);
            object newValue;
            try
            {
                if (expanded)
                    newValue = EditorGUILayout.TextArea(value, GUILayout.MinHeight(50f));
                else
                {
                    newValue = EditorGUILayout.TextField(value);

                    if (GUILayout.Button("↓", GUILayout.Width(20f)))
                        _expanded = true;

                }

            }
            finally
            {
                context.EndLook();
            }
            if (!newValue.Equals(value))
            {
                Value = newValue;
                return true;
            }
            return false;
        }
    }
}