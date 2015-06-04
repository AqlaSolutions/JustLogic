using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Thread Priority")]
[UnitFriendlyName("WWW.Get Thread Priority")]
[UnitUsage(typeof(ThreadPriority), HideExpressionInActionsList = true)]
public class JLWwwGetThreadPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.threadPriority;
    }
}
