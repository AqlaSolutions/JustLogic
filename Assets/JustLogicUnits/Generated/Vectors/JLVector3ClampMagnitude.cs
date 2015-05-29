using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Vectors/Clamp Magnitude (Vector3)")]
[UnitFriendlyName("Clamp Magnitude")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLVector3ClampMagnitude : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Vector;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxLength;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Vector3.ClampMagnitude(Vector.GetResult<UnityEngine.Vector3>(context), MaxLength.GetResult<System.Single>(context));
    }
}
