using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Velocity (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Get Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLRigidbodyGetVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.velocity;
    }
}
