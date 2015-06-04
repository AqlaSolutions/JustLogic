using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set Center")]
[UnitFriendlyName("Rect.Set Center")]
[UnitUsage(typeof(Rect))]
public class JLRectSetCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        opValue.center = Value.GetResult<Vector2>(context);
        return opValue;
    }
}
