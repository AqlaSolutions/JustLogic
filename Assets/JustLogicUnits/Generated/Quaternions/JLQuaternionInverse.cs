using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Inverse")]
[UnitFriendlyName("Inverse")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionInverse : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Rotation;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Inverse(Rotation.GetResult<Quaternion>(context));
    }
}
