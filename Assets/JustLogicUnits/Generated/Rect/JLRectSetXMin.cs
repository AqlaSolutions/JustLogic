using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set XMin")]
[UnitFriendlyName("Rect.Set XMin")]
[UnitUsage(typeof(Rect))]
public class JLRectSetXMin : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        opValue.xMin = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
