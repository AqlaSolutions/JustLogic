using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Inverse Transform Point")]
[UnitFriendlyName("Inverse Transform Point")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLTransformInverseTransformPoint : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        return opValue.InverseTransformPoint(Position.GetResult<UnityEngine.Vector3>(context));
    }
}
