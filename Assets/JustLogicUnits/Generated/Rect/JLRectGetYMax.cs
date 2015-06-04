using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get YMax")]
[UnitFriendlyName("Rect.Get YMax")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetYMax : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.yMax;
    }
}
