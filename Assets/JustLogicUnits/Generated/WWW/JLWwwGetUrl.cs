using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Url")]
[UnitFriendlyName("WWW.Get Url")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwGetUrl : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.url;
    }
}
