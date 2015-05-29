using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Get Sleep Angular Velocity")]
[UnitFriendlyName("Physics.Get Sleep Angular Velocity")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLPhysicsGetSleepAngularVelocity : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.sleepAngularVelocity;
    }
}
