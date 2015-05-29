using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Set Target Frame Rate")]
[UnitFriendlyName("Set Target Frame Rate")]
[UnitUsage(typeof(System.Int32))]
public class JLAppSetTargetFrameRate : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.targetFrameRate = Value.GetResult<System.Int32>(context);
    }
}
