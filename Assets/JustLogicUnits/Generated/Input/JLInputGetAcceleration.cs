using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Acceleration")]
[UnitFriendlyName("Get Acceleration")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLInputGetAcceleration : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.acceleration;
    }
}
