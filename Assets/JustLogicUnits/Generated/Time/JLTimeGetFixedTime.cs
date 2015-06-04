using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Fixed Time")]
[UnitFriendlyName("Get Fixed Time")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetFixedTime : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.fixedTime;
    }
}
