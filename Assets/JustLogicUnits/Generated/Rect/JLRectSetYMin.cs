using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set YMin")]
[UnitFriendlyName("Rect.Set YMin")]
[UnitUsage(typeof(UnityEngine.Rect))]
public class JLRectSetYMin : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        opValue.yMin = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
