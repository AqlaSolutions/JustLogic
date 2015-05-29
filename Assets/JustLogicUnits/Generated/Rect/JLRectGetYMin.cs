using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get YMin")]
[UnitFriendlyName("Rect.Get YMin")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetYMin : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        return opValue.yMin;
    }
}
