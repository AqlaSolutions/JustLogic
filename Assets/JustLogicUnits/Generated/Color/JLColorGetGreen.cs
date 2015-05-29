using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Green")]
[UnitFriendlyName("Color.Get Green")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorGetGreen : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Color.green;
    }
}
