using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Simulate Mouse With Touches")]
[UnitFriendlyName("Get Simulate Mouse With Touches")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetSimulateMouseWithTouches : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.simulateMouseWithTouches;
    }
}
