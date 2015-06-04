using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Normalized (Vector4)")]
[UnitFriendlyName("Get Normalized")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4GetNormalized : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        return opValue.normalized;
    }
}
