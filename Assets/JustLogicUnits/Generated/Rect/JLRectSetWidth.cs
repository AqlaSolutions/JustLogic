using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set Width")]
[UnitFriendlyName("Rect.Set Width")]
[UnitUsage(typeof(UnityEngine.Rect))]
public class JLRectSetWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        opValue.width = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
