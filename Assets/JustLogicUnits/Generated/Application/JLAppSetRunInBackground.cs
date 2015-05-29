using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Set Run In Background")]
[UnitFriendlyName("Set Run In Background")]
[UnitUsage(typeof(System.Boolean))]
public class JLAppSetRunInBackground : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.runInBackground = Value.GetResult<System.Boolean>(context);
    }
}
