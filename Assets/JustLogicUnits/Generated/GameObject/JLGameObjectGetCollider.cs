using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Collider")]
[UnitFriendlyName("Get Collider")]
[UnitUsage(typeof(UnityEngine.Collider), HideExpressionInActionsList = true)]
public class JLGameObjectGetCollider : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        return opValue.GetComponent<Collider>();
    }
}
