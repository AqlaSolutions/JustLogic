using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Operations/Equality (Vector4)")]
[UnitFriendlyName("Op Equality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLVector4OpEquality : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<UnityEngine.Vector4>(context) == Rhs.GetResult<UnityEngine.Vector4>(context);
    }
}
