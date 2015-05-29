using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Get Sleep Velocity")]
[UnitFriendlyName("Physics.Get Sleep Velocity")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLPhysicsGetSleepVelocity : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.sleepVelocity;
    }
}
