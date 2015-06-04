using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Set Capture Framerate")]
[UnitFriendlyName("Set Capture Framerate")]
[UnitUsage(typeof(System.Int32))]
public class JLTimeSetCaptureFramerate : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.captureFramerate = Value.GetResult<System.Int32>(context);
    }
}
