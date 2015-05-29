using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Move Towards (Vector4)")]
[UnitFriendlyName("Move Towards")]
[UnitUsage(typeof(UnityEngine.Vector4), HideExpressionInActionsList = true)]
public class JLVector4MoveTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Current;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector4))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDistanceDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector4.MoveTowards(Current.GetResult<UnityEngine.Vector4>(context), Target.GetResult<UnityEngine.Vector4>(context), MaxDistanceDelta.GetResult<System.Single>(context));
    }
}
