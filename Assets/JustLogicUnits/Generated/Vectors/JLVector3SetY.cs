using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Set/Set Y (Vector3)")]
[UnitFriendlyName("Set Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3SetY : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector3 opValue = Target.GetResult<Vector3>(context);
        return opValue.y = Value.GetResult<System.Single>(context);
    }
}
