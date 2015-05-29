using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set Center")]
[UnitFriendlyName("Rect.Set Center")]
[UnitUsage(typeof(UnityEngine.Rect))]
public class JLRectSetCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        opValue.center = Value.GetResult<UnityEngine.Vector2>(context);
        return opValue;
    }
}
