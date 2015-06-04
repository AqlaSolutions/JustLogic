using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Transform Point")]
[UnitFriendlyName("Transform Point")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLTransformTransformPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.TransformPoint(Position.GetResult<Vector3>(context));
    }
}
