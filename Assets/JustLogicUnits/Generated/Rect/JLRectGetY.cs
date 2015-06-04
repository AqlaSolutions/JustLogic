using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get Y")]
[UnitFriendlyName("Rect.Get Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetY : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.y;
    }
}
