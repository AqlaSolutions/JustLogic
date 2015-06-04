using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Transform")]
[UnitFriendlyName("Collision.Get Transform")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLCollisionGetTransform : JLExpression
{
    [Parameter(ExpressionType = typeof(Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collision opValue = OperandValue.GetResult<Collision>(context);
        return opValue.transform;
    }
}
