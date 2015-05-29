using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Is Done")]
[UnitFriendlyName("WWW.Get Is Done")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLWwwGetIsDone : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.isDone;
    }
}
