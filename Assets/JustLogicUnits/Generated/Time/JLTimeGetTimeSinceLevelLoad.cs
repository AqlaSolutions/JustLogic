using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Time Since Level Load")]
[UnitFriendlyName("Get Time Since Level Load")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLTimeGetTimeSinceLevelLoad : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Time.timeSinceLevelLoad;
    }
}
