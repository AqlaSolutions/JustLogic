using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get X (Vector4)")]
[UnitFriendlyName("Get X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4GetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        return opValue.x;
    }
}
