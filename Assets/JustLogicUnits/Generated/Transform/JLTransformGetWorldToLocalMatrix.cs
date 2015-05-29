using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get World To Local Matrix")]
[UnitFriendlyName("Get World To Local Matrix")]
[UnitUsage(typeof(UnityEngine.Matrix4x4), HideExpressionInActionsList = true)]
public class JLTransformGetWorldToLocalMatrix : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.worldToLocalMatrix;
    }
}
