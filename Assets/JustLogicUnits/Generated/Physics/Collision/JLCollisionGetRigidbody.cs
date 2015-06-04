using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Rigidbody")]
[UnitFriendlyName("Collision.Get Rigidbody")]
[UnitUsage(typeof(Rigidbody), HideExpressionInActionsList = true)]
public class JLCollisionGetRigidbody : JLExpression
{
    [Parameter(ExpressionType = typeof(Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collision opValue = OperandValue.GetResult<Collision>(context);
        return opValue.rigidbody;
    }
}
