using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Smooth Delta Time")]
[UnitFriendlyName("Get Smooth Delta Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetSmoothDeltaTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.smoothDeltaTime;
    }
}
