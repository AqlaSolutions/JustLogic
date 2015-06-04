using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Delta Time")]
[UnitFriendlyName("Get Delta Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetDeltaTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.deltaTime;
    }
}
