using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Maximum Delta Time")]
[UnitFriendlyName("Get Maximum Delta Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetMaximumDeltaTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.maximumDeltaTime;
    }
}
