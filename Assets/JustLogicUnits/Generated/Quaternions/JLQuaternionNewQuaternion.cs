using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/New Quaternion")]
[UnitFriendlyName("New Quaternion")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionNewQuaternion : JLExpression
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
        return new Quaternion(X.GetResult<System.Single>(context), Y.GetResult<System.Single>(context), Z.GetResult<System.Single>(context), W.GetResult<System.Single>(context));
    }
}
