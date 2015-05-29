using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Rigidbody")]
[UnitFriendlyName("Collision.Get Rigidbody")]
[UnitUsage(typeof(UnityEngine.Rigidbody), HideExpressionInActionsList = true)]
public class JLCollisionGetRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collision opValue = OperandValue.GetResult<UnityEngine.Collision>(context);
        return opValue.rigidbody;
    }
}
