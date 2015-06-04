using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Fixed Delta Time")]
[UnitFriendlyName("Get Fixed Delta Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetFixedDeltaTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.fixedDeltaTime;
    }
}
