using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Set YMax")]
[UnitFriendlyName("Rect.Set YMax")]
[UnitUsage(typeof(Rect))]
public class JLRectSetYMax : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        opValue.yMax = Value.GetResult<System.Single>(context);
        return opValue;
    }
}
