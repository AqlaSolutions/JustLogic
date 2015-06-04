using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Normalize (Vector4)")]
[UnitFriendlyName("Normalize")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4Normalize : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        opValue.Normalize();
        return opValue;
    }
}
