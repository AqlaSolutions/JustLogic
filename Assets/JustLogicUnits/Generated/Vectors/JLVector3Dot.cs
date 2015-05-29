using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Dot (Vector3)")]
[UnitFriendlyName("Dot")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3Dot : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.Dot(Lhs.GetResult<UnityEngine.Vector3>(context), Rhs.GetResult<UnityEngine.Vector3>(context));
    }
}
