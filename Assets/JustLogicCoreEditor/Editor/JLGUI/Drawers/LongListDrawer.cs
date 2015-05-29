using System;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    public class LongListDrawer : IParameterDrawer
    {
        protected LongListSelector Selector { get; private set; }

        public LongListDrawer(LongListSelector selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            Selector = selector;
        }

        public virtual object Value { get; protected set; }
        public ParameterDrawerLayout Layout { get { return ParameterDrawerLayout.VerticalRoot; } }
        public ParameterDrawerLayout SelfLayout { get { return ParameterDrawerLayout.VerticalRoot; } }
        public virtual string Label { get { return "Type: "; } }

        public bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            if (value == null)
                value = string.Empty;
            else if (value is Type)
                value = ((Type)value).FullName;
            else if (!(value is string))
                return false;
            Value = value;
            GUIContent label = args.Label;
            if (label != null)
                Selector.PrefixLabel = !string.IsNullOrEmpty(label.text) ? label.text : Label;
            else
                Selector.PrefixLabel = Label;
            Selector.FullValue = (string)value;
            return true;
        }

        protected virtual bool DrawSelector(IDrawContext context)
        {
            return Selector.Draw(context);
        }

        public virtual bool Draw(IDrawContext context)
        {
            bool changed = DrawSelector(context);
            if (changed)
            {
                Value = Selector.FullValue;
                return true;
            }
            return false;
        }

        public void UpdateLayoutType(int parentsFromHorizontalStart, IDrawContext context, out int horizontalChildren, out int maxDepth, out bool isTuple)
        {
            horizontalChildren = 0;
            maxDepth = 0;
            isTuple = false;
        }

        public virtual void Dispose()
        {

        }
    }
}