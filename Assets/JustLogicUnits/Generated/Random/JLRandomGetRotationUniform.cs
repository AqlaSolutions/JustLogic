using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get Rotation Uniform")]
[UnitFriendlyName("Random.Get Rotation Uniform")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLRandomGetRotationUniform : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.rotationUniform;
    }
}
