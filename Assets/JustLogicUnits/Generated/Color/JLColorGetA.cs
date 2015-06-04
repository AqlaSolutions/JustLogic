using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get A")]
[UnitFriendlyName("Color.Get A")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetA : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = OperandValue.GetResult<Color>(context);
        return opValue.a;
    }
}
