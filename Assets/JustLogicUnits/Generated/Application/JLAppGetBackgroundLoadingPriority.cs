using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Background Loading Priority")]
[UnitFriendlyName("Get Background Loading Priority")]
[UnitUsage(typeof(UnityEngine.ThreadPriority), HideExpressionInActionsList = true)]
public class JLAppGetBackgroundLoadingPriority : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.backgroundLoadingPriority;
    }
}
