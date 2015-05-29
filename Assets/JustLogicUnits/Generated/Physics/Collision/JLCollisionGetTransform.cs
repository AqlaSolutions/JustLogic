using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Transform")]
[UnitFriendlyName("Collision.Get Transform")]
[UnitUsage(typeof(UnityEngine.Transform), HideExpressionInActionsList = true)]
public class JLCollisionGetTransform : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collision opValue = OperandValue.GetResult<UnityEngine.Collision>(context);
        return opValue.transform;
    }
}
