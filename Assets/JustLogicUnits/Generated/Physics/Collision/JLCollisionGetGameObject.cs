using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Collision/Get Game Object")]
[UnitFriendlyName("Collision.Get Game Object")]
[UnitUsage(typeof(UnityEngine.GameObject), HideExpressionInActionsList = true)]
public class JLCollisionGetGameObject : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Collision))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Collision opValue = OperandValue.GetResult<UnityEngine.Collision>(context);
        return opValue.gameObject;
    }
}
