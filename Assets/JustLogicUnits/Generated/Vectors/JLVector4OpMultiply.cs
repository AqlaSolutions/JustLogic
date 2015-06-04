using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Multiply (Vector4)")]
[UnitFriendlyName("Op Multiply")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4OpMultiply : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression D;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Vector4>(context) * D.GetResult<System.Single>(context);
    }
}
