using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Time/Set Maximum Delta Time")]
[UnitFriendlyName("Set Maximum Delta Time")]
[UnitUsage(typeof(System.Single))]
public class JLTimeSetMaximumDeltaTime : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Time.maximumDeltaTime = Value.GetResult<System.Single>(context);
    }
}
