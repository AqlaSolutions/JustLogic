using System;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    /// <summary>
    /// Если есть label, то рисуется в отдельной строке. Если label отсутствует, рисует в той же
    /// </summary>
    public abstract class AutoHorizontalLayoutedDrawer : ParameterDrawerBase
    {
        public override sealed ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.HorizontalLimited; } protected set { } }

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            bool r = base.Initialize(args, value, context);
            if (r)
            {
                if (Label != null && string.IsNullOrEmpty(Label.text))
                    Label = null;
            }
            return r;
        }

        public override sealed void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            base.UpdateLayoutType(parentsFromHorizontalStart, context, out horizontalChildren, out maxDepth, out isTuple);

            bool isHorizontal = Label == null || parentsFromHorizontalStart < 2;
            Layout = isHorizontal ? ParameterDrawerLayout.HorizontalLimited : ParameterDrawerLayout.VerticalRoot;
        }

        public override sealed GUIContent Label { get { return base.Label; } set { base.Label = value; } }
        public override sealed ParameterDrawerLayout Layout { get { return base.Layout; } protected set { base.Layout = value; } }

        protected override sealed void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            //hasVerticalOutline = !_isEmptyLabel;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override sealed bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            if (Layout.IsHorizontal())
                GUILayout.Space(25f);
            return OnDraw(context);
        }

        protected abstract bool OnDraw(IDrawContext context);
    }
}