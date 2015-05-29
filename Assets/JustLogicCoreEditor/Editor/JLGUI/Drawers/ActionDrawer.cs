using System.Collections.Generic;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(JLAction), Order = int.MaxValue)]
    public class ActionDrawer : UnitDrawerBase
    {
        static GUIStyle _toggleStyle;
        static GUIStyle _toggleStyleOn;
        static bool _isStaticInited;

        public ActionDrawer()
        {
            if (!_isStaticInited)
            {
                _toggleStyle = new GUIStyle(StylesCache.toggle) { fixedWidth = 15f };
                _toggleStyle.margin.top += 1;
                _toggleStyleOn = new GUIStyle(_toggleStyle) { normal = _toggleStyle.onNormal };
                _isStaticInited = true;
            }
        }

        protected override void GetUnits(out IList<TypeInfo> units, out object cacheKey)
        {
            units = DrawersLibrary.GetActions(InitArgs.SupportedType);
            cacheKey = InitArgs.SupportedType;
        }

        bool _changed;

        protected override void DrawLabel(GUIContent label, bool isAppendedToHorizontal, ref bool hasVerticalOutline, IDrawContext context)
        {
            if (GUILayout.Button(" ", (!Unit || Unit.On) ? _toggleStyleOn : _toggleStyle) && Unit)
            {
                Unit.On = !Unit.On;
                _changed = true;
            }
            base.DrawLabel(label, isAppendedToHorizontal, ref hasVerticalOutline, context);
        }

        protected override bool OnDraw(IDrawContext context, bool isNewAreaStarted)
        {
            bool changed = _changed;
            _changed = false;
            return base.OnDraw(context, isNewAreaStarted) || changed;
        }

        public override object Value { get { return base.Value; } protected set { Unit = (JLAction)value; } }

        public new JLAction Unit { get { return (JLAction)base.Value; } protected set { base.Value = value; } }

    }
}