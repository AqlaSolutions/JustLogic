using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Get/Get Y (Vector4)")]
[UnitFriendlyName("Get Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector4GetY : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector4 opValue = OperandValue.GetResult<Vector4>(context);
        return opValue.y;
    }
}
