using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Item")]
[UnitFriendlyName("Color.Get Item")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLColorGetItem : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color opValue = OperandValue.GetResult<UnityEngine.Color>(context);
        return opValue[Index.GetResult<System.Int32>(context)];
    }
}
