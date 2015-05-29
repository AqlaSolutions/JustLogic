using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Error")]
[UnitFriendlyName("WWW.Get Error")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLWwwGetError : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.error;
    }
}
