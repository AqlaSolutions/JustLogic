using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Game Object")]
[UnitFriendlyName("Get Game Object")]
[UnitUsage(typeof(GameObject), HideExpressionInActionsList = true)]
public class JLTransformGetGameObject : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.gameObject;
    }
}
