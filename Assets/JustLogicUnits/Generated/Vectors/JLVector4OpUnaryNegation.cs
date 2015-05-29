using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Unary Negation (Vector4)")]
[UnitFriendlyName("Op Unary Negation")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4OpUnaryNegation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return -A.GetResult<UnityEngine.Vector4>(context);
    }
}
