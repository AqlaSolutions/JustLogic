using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Max (Vector4)")]
[UnitFriendlyName("Max")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4Max : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector4.Max(Lhs.GetResult<UnityEngine.Vector4>(context), Rhs.GetResult<UnityEngine.Vector4>(context));
    }
}
