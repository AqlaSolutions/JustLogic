using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get Width")]
[UnitFriendlyName("Rect.Get Width")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.width;
    }
}
