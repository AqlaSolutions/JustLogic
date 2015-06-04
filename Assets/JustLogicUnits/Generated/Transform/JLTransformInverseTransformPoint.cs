using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Inverse Transform Point")]
[UnitFriendlyName("Inverse Transform Point")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLTransformInverseTransformPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.InverseTransformPoint(Position.GetResult<Vector3>(context));
    }
}
