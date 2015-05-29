using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get Rotation")]
[UnitFriendlyName("Random.Get Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLRandomGetRotation : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.rotation;
    }
}
