using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Get Thread Priority")]
[UnitFriendlyName("WWW.Get Thread Priority")]
[UnitUsage(typeof(UnityEngine.ThreadPriority), HideExpressionInActionsList = true)]
public class JLWwwGetThreadPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.threadPriority;
    }
}
