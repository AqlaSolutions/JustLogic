using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Time")]
[UnitFriendlyName("Get Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.time;
    }
}
