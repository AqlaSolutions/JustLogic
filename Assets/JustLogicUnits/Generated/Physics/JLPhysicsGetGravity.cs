using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Get Gravity")]
[UnitFriendlyName("Physics.Get Gravity")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLPhysicsGetGravity : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.gravity;
    }
}
