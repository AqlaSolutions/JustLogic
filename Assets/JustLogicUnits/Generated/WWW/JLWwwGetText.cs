using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Text")]
[UnitFriendlyName("WWW.Get Text")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwGetText : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.text;
    }
}
