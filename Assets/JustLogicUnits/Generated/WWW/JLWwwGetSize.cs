using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Size")]
[UnitFriendlyName("WWW.Get Size")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLWwwGetSize : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.size;
    }
}
