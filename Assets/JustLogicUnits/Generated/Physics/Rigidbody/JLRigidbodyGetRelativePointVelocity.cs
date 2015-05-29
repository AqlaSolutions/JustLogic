using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Relative Point Velocity (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Get Relative Point Velocity")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLRigidbodyGetRelativePointVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression RelativePoint;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        return opValue.GetRelativePointVelocity(RelativePoint.GetResult<UnityEngine.Vector3>(context));
    }
}
