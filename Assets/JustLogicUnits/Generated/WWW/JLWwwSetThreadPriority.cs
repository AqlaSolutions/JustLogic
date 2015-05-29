using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Set Thread Priority")]
[UnitFriendlyName("WWW.Set Thread Priority")]
[UnitUsage(typeof(UnityEngine.ThreadPriority))]
public class JLWwwSetThreadPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.WWW))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.ThreadPriority))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.WWW opValue = OperandValue.GetResult<UnityEngine.WWW>(context);
        return opValue.threadPriority = Value.GetResult<UnityEngine.ThreadPriority>(context);
    }
}
