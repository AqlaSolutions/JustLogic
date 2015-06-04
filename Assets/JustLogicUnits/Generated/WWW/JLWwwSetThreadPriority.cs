using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("WWW/Set Thread Priority")]
[UnitFriendlyName("WWW.Set Thread Priority")]
[UnitUsage(typeof(ThreadPriority))]
public class JLWwwSetThreadPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(WWW))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(ThreadPriority))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        WWW opValue = OperandValue.GetResult<WWW>(context);
        return opValue.threadPriority = Value.GetResult<ThreadPriority>(context);
    }
}
