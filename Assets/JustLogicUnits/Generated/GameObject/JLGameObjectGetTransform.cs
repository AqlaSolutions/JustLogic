using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Get Transform")]
[UnitFriendlyName("Get Transform")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLGameObjectGetTransform : JLExpression
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        return opValue.transform;
    }
}
