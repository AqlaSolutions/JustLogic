using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Local To World Matrix")]
[UnitFriendlyName("Get Local To World Matrix")]
[UnitUsage(typeof(Matrix4x4), HideExpressionInActionsList = true)]
public class JLTransformGetLocalToWorldMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.localToWorldMatrix;
    }
}
