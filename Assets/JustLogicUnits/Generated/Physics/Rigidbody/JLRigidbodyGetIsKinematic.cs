using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Is Kinematic (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Get Is Kinematic")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRigidbodyGetIsKinematic : JLExpression
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        return opValue.isKinematic;
    }
}
