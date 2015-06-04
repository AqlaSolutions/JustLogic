using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Error")]
[UnitFriendlyName("WWW.Get Error")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwGetError : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.error;
    }
}
