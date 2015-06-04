using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Sqr Magnitude (Vector4)")]
[UnitFriendlyName("Sqr Magnitude")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4SqrMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        return opValue.SqrMagnitude();
    }
}
