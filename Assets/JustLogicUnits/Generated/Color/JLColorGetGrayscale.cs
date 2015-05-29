using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Grayscale")]
[UnitFriendlyName("Color.Get Grayscale")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetGrayscale : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = OperandValue.GetResult<UnityEngine.Color>(context);
        return opValue.grayscale;
    }
}
