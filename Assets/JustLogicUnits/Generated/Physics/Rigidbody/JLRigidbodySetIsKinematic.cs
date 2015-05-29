using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Set Is Kinematic (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Set Is Kinematic")]
[UnitUsage(typeof(System.Boolean))]
public class JLRigidbodySetIsKinematic : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        return opValue.isKinematic = Value.GetResult<System.Boolean>(context);
    }
}
