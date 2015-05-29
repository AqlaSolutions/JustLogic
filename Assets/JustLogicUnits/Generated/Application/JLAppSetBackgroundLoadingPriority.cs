using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Set Background Loading Priority")]
[UnitFriendlyName("Set Background Loading Priority")]
[UnitUsage(typeof(UnityEngine.ThreadPriority))]
public class JLAppSetBackgroundLoadingPriority : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.ThreadPriority))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.backgroundLoadingPriority = Value.GetResult<UnityEngine.ThreadPriority>(context);
    }
}
