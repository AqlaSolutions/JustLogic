using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Yellow")]
[UnitFriendlyName("Color.Get Yellow")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorGetYellow : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Color.yellow;
    }
}
