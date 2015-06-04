using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set X")]
[UnitFriendlyName("Rect.Set X")]
[UnitUsage(typeof(Rect))]
public class JLRectSetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        opValue.x = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
