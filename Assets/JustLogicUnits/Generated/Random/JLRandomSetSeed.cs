using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Set Seed")]
[UnitFriendlyName("Random.Set Seed")]
[UnitUsage(typeof(System.Int32))]
public class JLRandomSetSeed : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.seed = Value.GetResult<System.Int32>(context);
    }
}
