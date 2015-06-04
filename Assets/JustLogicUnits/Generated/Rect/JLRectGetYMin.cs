using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get YMin")]
[UnitFriendlyName("Rect.Get YMin")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetYMin : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.yMin;
    }
}
