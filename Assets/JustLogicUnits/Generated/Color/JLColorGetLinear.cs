using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Linear")]
[UnitFriendlyName("Color.Get Linear")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetLinear : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = OperandValue.GetResult<Color>(context);
        return opValue.linear;
    }
}
