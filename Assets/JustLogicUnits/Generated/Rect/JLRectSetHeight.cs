using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set Height")]
[UnitFriendlyName("Rect.Set Height")]
[UnitUsage(typeof(Rect))]
public class JLRectSetHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        opValue.height = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
