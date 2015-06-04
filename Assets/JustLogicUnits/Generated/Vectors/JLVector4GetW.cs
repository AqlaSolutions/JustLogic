using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get W (Vector4)")]
[UnitFriendlyName("Get W")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4GetW : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        return opValue.w;
    }
}
