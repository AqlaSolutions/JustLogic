using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get B")]
[UnitFriendlyName("Color.Get B")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetB : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = OperandValue.GetResult<UnityEngine.Color>(context);
        return opValue.b;
    }
}
