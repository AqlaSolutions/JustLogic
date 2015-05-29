using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set XMin")]
[UnitFriendlyName("Rect.Set XMin")]
[UnitUsage(typeof(UnityEngine.Rect))]
public class JLRectSetXMin : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        opValue.xMin = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
