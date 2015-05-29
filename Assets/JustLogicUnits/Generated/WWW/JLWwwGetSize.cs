using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Size")]
[UnitFriendlyName("WWW.Get Size")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLWwwGetSize : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.size;
    }
}
