using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get XMin")]
[UnitFriendlyName("Rect.Get XMin")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetXMin : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.xMin;
    }
}
