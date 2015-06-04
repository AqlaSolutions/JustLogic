using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Game Object")]
[UnitFriendlyName("Collision.Get Game Object")]
[UnitUsage(typeof(GameObject), HideExpressionInActionsList = true)]
public class JLCollisionGetGameObject : JLExpression
{
    [Parameter(ExpressionType = typeof(Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Collision opValue = OperandValue.GetResult<Collision>(context);
        return opValue.gameObject;
    }
}
