using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get Center")]
[UnitFriendlyName("Rect.Get Center")]
[UnitUsage(typeof(Vector2), HideExpressionInActionsList = true)]
public class JLRectGetCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.center;
    }
}
