using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Realtime Since Startup")]
[UnitFriendlyName("Get Realtime Since Startup")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetRealtimeSinceStartup : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.realtimeSinceStartup;
    }
}
