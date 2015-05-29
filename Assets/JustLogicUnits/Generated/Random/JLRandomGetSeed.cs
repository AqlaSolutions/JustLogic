using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get Seed")]
[UnitFriendlyName("Random.Get Seed")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLRandomGetSeed : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.seed;
    }
}
