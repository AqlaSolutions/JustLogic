using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Velocity (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Set Velocity")]
[UnitUsage(typeof(Vector3))]
public class JLRigidbodySetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.velocity = Value.GetResult<Vector3>(context);
    }
}
