using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Acceleration Event Count")]
[UnitFriendlyName("Get Acceleration Event Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLInputGetAccelerationEventCount : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.accelerationEventCount;
    }
}
