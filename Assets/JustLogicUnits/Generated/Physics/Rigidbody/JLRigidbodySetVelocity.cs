using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Velocity (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Set Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLRigidbodySetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        return opValue.velocity = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
