using System;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(SerializedEnumBase))]
    public class SerializedEnumDrawer : ParameterDrawerBase
    {
        public enum EmptyEnum
        {
            None = 0
        }
        readonly LongListSelector _typeSelector = new LongListSelector(DrawersLibrary.EnumListShort, DrawersLibrary.EnumList, label: "Enum: ", filter: "UnityEngine.");

        public override bool Initialize(DrawerInitArgs args, object value, IDrawContext context)
        {
            Layout = ParameterDrawerLayout.VerticalRoot;
            return base.Initialize(args, value, context);
        }

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            hasVerticalOutline = !isAppendedToHorizontal && label != null;
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = false;
            var value = (SerializedEnumBase)Value ?? Library.Instantiator.CreateSerializedEnumBase();

            context.BeginLook(true);
            try
            {
                if (string.IsNullOrEmpty(value.TypeFullName))
                    value.TypeFullName = typeof(EmptyEnum).FullName;
                _typeSelector.CurrentValueIndex = DrawersLibrary.EnumList.IndexOf(value.TypeFullName);
                if (_typeSelector.Draw(context))
                {
                    value.TypeFullName = _typeSelector.FullValue;
                    changed = true;
                }

                var enumType = Library.FindType(value.TypeFullName);

                object newValue = Enum.ToObject(enumType, value.Value);
                if (ConcreteEnumDrawer.DrawEnum(ref newValue, enumType))
                {
                    changed = true;
                    value.Value = (int)Convert.ChangeType(Convert.ChangeType(newValue, Enum.GetUnderlyingType(enumType)), typeof(int));
                }
            }
            finally { context.EndLook(); }
            if (changed)
                Value = value;
            return changed;
        }

    }
}