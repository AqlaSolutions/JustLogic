using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Set Fixed Delta Time")]
[UnitFriendlyName("Set Fixed Delta Time")]
[UnitUsage(typeof(System.Single))]
public class JLTimeSetFixedDeltaTime : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Time.fixedDeltaTime = Value.GetResult<System.Single>(context);
    }
}
