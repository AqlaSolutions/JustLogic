using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Get Capture Framerate")]
[UnitFriendlyName("Get Capture Framerate")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLTimeGetCaptureFramerate : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.captureFramerate;
    }
}
