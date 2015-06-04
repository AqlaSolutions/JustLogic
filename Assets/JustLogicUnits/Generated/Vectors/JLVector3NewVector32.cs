using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/New Vector3")]
[UnitFriendlyName("New Vector3")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLVector3NewVector32 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression X;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Y;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Z;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new Vector3(X.GetResult<System.Single>(context), Y.GetResult<System.Single>(context), Z.GetResult<System.Single>(context));
    }
}
