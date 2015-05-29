using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Contains")]
[UnitFriendlyName("Rect.Contains")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRectContains3 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Point;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression AllowInverse;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        return opValue.Contains(Point.GetResult<UnityEngine.Vector3>(context), AllowInverse.GetResult<System.Boolean>(context));
    }
}
