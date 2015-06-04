using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Relative Velocity")]
[UnitFriendlyName("Collision.Get Relative Velocity")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLCollisionGetRelativeVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collision opValue = OperandValue.GetResult<Collision>(context);
        return opValue.relativeVelocity;
    }
}
