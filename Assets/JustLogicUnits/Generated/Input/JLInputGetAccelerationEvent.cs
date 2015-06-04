using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Acceleration Event")]
[UnitFriendlyName("Get Acceleration Event")]
[UnitUsage(typeof(AccelerationEvent), HideExpressionInActionsList = true)]
public class JLInputGetAccelerationEvent : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.GetAccelerationEvent(Index.GetResult<System.Int32>(context));
    }
}
