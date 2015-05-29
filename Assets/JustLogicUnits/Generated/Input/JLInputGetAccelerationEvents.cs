using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Acceleration Events")]
[UnitFriendlyName("Get Acceleration Events")]
[UnitUsage(typeof(UnityEngine.AccelerationEvent[]), HideExpressionInActionsList = true)]
public class JLInputGetAccelerationEvents : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.accelerationEvents;
    }
}
