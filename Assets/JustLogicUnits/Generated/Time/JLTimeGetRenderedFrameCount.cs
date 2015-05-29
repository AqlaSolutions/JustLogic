using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Rendered Frame Count")]
[UnitFriendlyName("Get Rendered Frame Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLTimeGetRenderedFrameCount : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Time.renderedFrameCount;
    }
}
