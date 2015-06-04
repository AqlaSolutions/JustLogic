using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Gamma")]
[UnitFriendlyName("Color.Get Gamma")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetGamma : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color opValue = OperandValue.GetResult<Color>(context);
        return opValue.gamma;
    }
}
