using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Bounce Threshold")]
[UnitFriendlyName("Physics.Set Bounce Threshold")]
[UnitUsage(typeof(System.Single))]
public class JLPhysicsSetBounceThreshold : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.bounceThreshold = Value.GetResult<System.Single>(context);
    }
}
