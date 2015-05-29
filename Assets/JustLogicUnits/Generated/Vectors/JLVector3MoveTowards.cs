using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Move Towards (Vector3)")]
[UnitFriendlyName("Move Towards")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3MoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDistanceDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.MoveTowards(Current.GetResult<UnityEngine.Vector3>(context), Target.GetResult<UnityEngine.Vector3>(context), MaxDistanceDelta.GetResult<System.Single>(context));
    }
}
