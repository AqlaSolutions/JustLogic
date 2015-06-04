using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Addition (Vector4)")]
[UnitFriendlyName("Op Addition")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4OpAddition : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Vector4))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Vector4>(context) + B.GetResult<Vector4>(context);
    }
}
