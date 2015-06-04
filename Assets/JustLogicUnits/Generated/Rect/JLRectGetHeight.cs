using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get Height")]
[UnitFriendlyName("Rect.Get Height")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.height;
    }
}
