using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Response Headers")]
[UnitFriendlyName("WWW.Get Response Headers")]
[UnitUsage(typeof(Dictionary<System.String, System.String>), HideExpressionInActionsList = true)]
public class JLWwwGetResponseHeaders : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.responseHeaders;
    }
}
