using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Compensate Sensors")]
[UnitFriendlyName("Get Compensate Sensors")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetCompensateSensors : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.compensateSensors;
    }
}
