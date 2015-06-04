using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Url")]
[UnitFriendlyName("WWW.Get Url")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwGetUrl : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.url;
    }
}
