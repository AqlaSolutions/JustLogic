using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get R")]
[UnitFriendlyName("Color.Get R")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetR : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = OperandValue.GetResult<UnityEngine.Color>(context);
        return opValue.r;
    }
}
