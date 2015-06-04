using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Set/Set X (Vector3)")]
[UnitFriendlyName("Set X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLVector3SetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Vector3 opValue = Target.GetResult<Vector3>(context);
        return opValue.x = Value.GetResult<System.Single>(context);
    }
}
