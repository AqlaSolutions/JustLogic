using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get G")]
[UnitFriendlyName("Color.Get G")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetG : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = OperandValue.GetResult<Color>(context);
        return opValue.g;
    }
}
