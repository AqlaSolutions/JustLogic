using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Min (Vector3)")]
[UnitFriendlyName("Min")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Min : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.Min(Lhs.GetResult<UnityEngine.Vector3>(context), Rhs.GetResult<UnityEngine.Vector3>(context));
    }
}
