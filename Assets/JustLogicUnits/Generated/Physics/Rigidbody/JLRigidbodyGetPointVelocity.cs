using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Point Velocity (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Get Point Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLRigidbodyGetPointVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression WorldPoint;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        return opValue.GetPointVelocity(WorldPoint.GetResult<UnityEngine.Vector3>(context));
    }
}
