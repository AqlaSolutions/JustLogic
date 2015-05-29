/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Penetration Penalty Force")]
[UnitFriendlyName("Physics.Set Penetration Penalty Force")]
[UnitUsage(typeof(System.Single))]
public class JLPhysicsSetPenetrationPenaltyForce : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.penetrationPenaltyForce = Value.GetResult<System.Single>(context);
    }
}
*/