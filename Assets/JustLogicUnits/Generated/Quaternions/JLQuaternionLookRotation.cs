using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Look Rotation")]
[UnitFriendlyName("Look Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionLookRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Forward;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.LookRotation(Forward.GetResult<UnityEngine.Vector3>(context));
    }
}
