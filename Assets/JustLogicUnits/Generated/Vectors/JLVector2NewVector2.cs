using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/New Vector2")]
[UnitFriendlyName("New Vector2")]
[UnitUsage(typeof(UnityEngine.Vector2), HideExpressionInActionsList = true)]
public class JLVector2NewVector2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression X;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Y;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.Vector2(X.GetResult<System.Single>(context), Y.GetResult<System.Single>(context));
    }
}
