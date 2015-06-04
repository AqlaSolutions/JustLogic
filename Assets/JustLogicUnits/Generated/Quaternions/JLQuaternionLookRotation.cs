using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Look Rotation")]
[UnitFriendlyName("Look Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionLookRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Forward;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.LookRotation(Forward.GetResult<Vector3>(context));
    }
}
