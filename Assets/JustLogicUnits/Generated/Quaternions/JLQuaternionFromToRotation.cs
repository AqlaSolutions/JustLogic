using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/From To Rotation")]
[UnitFriendlyName("From To Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionFromToRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression FromDirection;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression ToDirection;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.FromToRotation(FromDirection.GetResult<UnityEngine.Vector3>(context), ToDirection.GetResult<UnityEngine.Vector3>(context));
    }
}
