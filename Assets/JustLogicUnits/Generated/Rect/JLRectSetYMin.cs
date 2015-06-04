using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set YMin")]
[UnitFriendlyName("Rect.Set YMin")]
[UnitUsage(typeof(Rect))]
public class JLRectSetYMin : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        opValue.yMin = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
