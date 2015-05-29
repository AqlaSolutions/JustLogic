using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Inverse")]
[UnitFriendlyName("Inverse")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionInverse : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Rotation;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.Inverse(Rotation.GetResult<UnityEngine.Quaternion>(context));
    }
}
