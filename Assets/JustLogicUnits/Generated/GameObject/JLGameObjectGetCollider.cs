using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Collider")]
[UnitFriendlyName("Get Collider")]
[UnitUsage(typeof(Collider), HideExpressionInActionsList = true)]
public class JLGameObjectGetCollider : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.GetComponent<Collider>();
    }
}
