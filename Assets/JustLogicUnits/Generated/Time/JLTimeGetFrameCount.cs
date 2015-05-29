using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Frame Count")]
[UnitFriendlyName("Get Frame Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLTimeGetFrameCount : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Time.frameCount;
    }
}
