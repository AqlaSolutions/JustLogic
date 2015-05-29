using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Lerp (Vector2)")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector2.Lerp(From.GetResult<UnityEngine.Vector2>(context), To.GetResult<UnityEngine.Vector2>(context), T.GetResult<System.Single>(context));
    }
}
