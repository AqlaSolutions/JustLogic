using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/New Vector4")]
[UnitFriendlyName("New Vector4")]
[UnitUsage(typeof(Vector4), HideExpressionInActionsList = true)]
public class JLVector4NewVector43 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression X;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Y;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Z;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression W;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new Vector4(X.GetResult<System.Single>(context), Y.GetResult<System.Single>(context), Z.GetResult<System.Single>(context), W.GetResult<System.Single>(context));
    }
}
