using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Sleep Angular Velocity")]
[UnitFriendlyName("Physics.Set Sleep Angular Velocity")]
[UnitUsage(typeof(System.Single))]
public class JLPhysicsSetSleepAngularVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.sleepAngularVelocity = Value.GetResult<System.Single>(context);
    }
}
