using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Gravity")]
[UnitFriendlyName("Physics.Set Gravity")]
[UnitUsage(typeof(UnityEngine.Vector3))]
public class JLPhysicsSetGravity : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.gravity = Value.GetResult<UnityEngine.Vector3>(context);
    }
}
