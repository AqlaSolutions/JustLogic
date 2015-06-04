using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get World To Local Matrix")]
[UnitFriendlyName("Get World To Local Matrix")]
[UnitUsage(typeof(Matrix4x4), HideExpressionInActionsList = true)]
public class JLTransformGetWorldToLocalMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.worldToLocalMatrix;
    }
}
