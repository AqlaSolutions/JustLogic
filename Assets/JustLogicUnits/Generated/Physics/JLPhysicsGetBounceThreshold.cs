using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Get Bounce Threshold")]
[UnitFriendlyName("Physics.Get Bounce Threshold")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLPhysicsGetBounceThreshold : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.bounceThreshold;
    }
}
