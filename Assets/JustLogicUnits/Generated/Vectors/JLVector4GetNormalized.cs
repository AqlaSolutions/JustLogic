using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Normalized (Vector4)")]
[UnitFriendlyName("Get Normalized")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4GetNormalized : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Vector4 opValue = OperandValue.GetResult<UnityEngine.Vector4>(context);
        return opValue.normalized;
    }
}
