using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Random/Get Value")]
[UnitFriendlyName("Random.Get Value")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRandomGetValue : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Random.value;
    }
}
