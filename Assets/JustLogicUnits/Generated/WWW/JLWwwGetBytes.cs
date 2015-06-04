using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Bytes")]
[UnitFriendlyName("WWW.Get Bytes")]
[UnitUsage(typeof(System.Byte[]), HideExpressionInActionsList = true)]
public class JLWwwGetBytes : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.bytes;
    }
}
