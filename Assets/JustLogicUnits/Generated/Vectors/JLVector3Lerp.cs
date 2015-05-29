using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Lerp (Vector3)")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.Lerp(From.GetResult<UnityEngine.Vector3>(context), To.GetResult<UnityEngine.Vector3>(context), T.GetResult<System.Single>(context));
    }
}
