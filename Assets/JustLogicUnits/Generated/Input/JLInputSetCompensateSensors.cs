using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Set Compensate Sensors")]
[UnitFriendlyName("Set Compensate Sensors")]
[UnitUsage(typeof(System.Boolean))]
public class JLInputSetCompensateSensors : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.compensateSensors = Value.GetResult<System.Boolean>(context);
    }
}
