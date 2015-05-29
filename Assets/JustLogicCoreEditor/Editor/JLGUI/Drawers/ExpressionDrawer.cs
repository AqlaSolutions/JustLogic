using System.Collections.Generic;
using JustLogic.Core;
using UnityEditor;
using UnityEngine;

namespace JustLogic.Editor.JLGUI.Drawers
{
    [ParameterDrawer(typeof(JLExpression), Order = int.MaxValue)]
    public class ExpressionDrawer : UnitDrawerBase
    {
        public new JLExpression Unit { get { return (JLExpression)base.Value; } protected set { base.Value = value; } }

        public override object Value { get { return base.Value; } protected set { Unit = (JLExpression)value; } }

        protected override void GetUnits(out IList<TypeInfo> units, out object cacheKey)
        {
            units = DrawersLibrary.GetExpressions(InitArgs.ExpressionType, InitArgs.SupportedType);
            cacheKey = new DrawersLibrary.TwoTypesKey(InitArgs.ExpressionType, InitArgs.SupportedType);
        }
    }
}