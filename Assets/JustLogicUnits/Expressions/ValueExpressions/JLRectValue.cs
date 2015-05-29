using JustLogic.Core;
using UnityEngine;

    [UnitMenu("Value/Rect")]
    [UnitUsage(typeof(Rect), HideExpressionInActionsList = true, IsDefaultExpression = true)]
    public class JLRectValue : JLExpression
    {
        [Parameter]
        public Rect Value;

        public override object GetAnyResult(IExecutionContext context)
        {
            return Value;
        }
    }
