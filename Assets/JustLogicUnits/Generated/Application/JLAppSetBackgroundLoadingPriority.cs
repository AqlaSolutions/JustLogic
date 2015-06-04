using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Set Background Loading Priority")]
[UnitFriendlyName("Set Background Loading Priority")]
[UnitUsage(typeof(ThreadPriority))]
public class JLAppSetBackgroundLoadingPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(ThreadPriority))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.backgroundLoadingPriority = Value.GetResult<ThreadPriority>(context);
    }
}
