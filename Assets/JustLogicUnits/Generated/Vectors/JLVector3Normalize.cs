using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Normalize (Vector3)")]
[UnitFriendlyName("Normalize")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3Normalize : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector3 opValue = OperandValue.GetResult<Vector3>(context);
        opValue.Normalize();
        return opValue;
    }
}
