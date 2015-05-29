using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set Height")]
[UnitFriendlyName("Rect.Set Height")]
[UnitUsage(typeof(UnityEngine.Rect))]
public class JLRectSetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        opValue.height = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
