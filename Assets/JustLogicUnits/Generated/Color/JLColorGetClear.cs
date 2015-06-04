using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Clear")]
[UnitFriendlyName("Color.Get Clear")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetClear : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.clear;
    }
}
