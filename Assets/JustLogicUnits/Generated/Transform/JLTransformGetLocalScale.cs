using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Local Scale")]
[UnitFriendlyName("Get Local Scale")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLTransformGetLocalScale : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.localScale;
    }
}
