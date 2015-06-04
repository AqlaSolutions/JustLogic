using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Attached Rigidbody (Collider)")]
[UnitFriendlyName("Collider.Get Attached Rigidbody")]
[UnitUsage(typeof(Rigidbody), HideExpressionInActionsList = true)]
public class JLColliderGetAttachedRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(Collider))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collider opValue = OperandValue.GetResult<Collider>(context);
        return opValue.attachedRigidbody;
    }
}
