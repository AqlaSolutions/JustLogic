using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Sleep Velocity")]
[UnitFriendlyName("Physics.Set Sleep Velocity")]
[UnitUsage(typeof(System.Single))]
public class JLPhysicsSetSleepVelocity : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.sleepVelocity = Value.GetResult<System.Single>(context);
    }
}
