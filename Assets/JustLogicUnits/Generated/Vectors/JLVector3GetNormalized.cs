using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Normalized (Vector3)")]
[UnitFriendlyName("Get Normalized")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3GetNormalized : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector3 opValue = OperandValue.GetResult<Vector3>(context);
        return opValue.normalized;
    }
}
