using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Gravity")]
[UnitFriendlyName("Physics.Set Gravity")]
[UnitUsage(typeof(Vector3))]
public class JLPhysicsSetGravity : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.gravity = Value.GetResult<Vector3>(context);
    }
}
