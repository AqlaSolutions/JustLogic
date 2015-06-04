using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get X")]
[UnitFriendlyName("Rect.Get X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.x;
    }
}
