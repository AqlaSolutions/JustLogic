using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Get Attached Rigidbody (Collider)")]
[UnitFriendlyName("Collider.Get Attached Rigidbody")]
[UnitUsage(typeof(UnityEngine.Rigidbody), HideExpressionInActionsList = true)]
public class JLColliderGetAttachedRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collider))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collider opValue = OperandValue.GetResult<UnityEngine.Collider>(context);
        return opValue.attachedRigidbody;
    }
}
