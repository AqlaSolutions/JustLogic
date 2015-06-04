using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get R")]
[UnitFriendlyName("Color.Get R")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetR : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = OperandValue.GetResult<Color>(context);
        return opValue.r;
    }
}
