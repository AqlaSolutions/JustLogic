using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Contains")]
[UnitFriendlyName("Rect.Contains")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRectContains2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Point;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.Contains(Point.GetResult<Vector3>(context));
    }
}
