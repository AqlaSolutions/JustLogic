using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Cyan")]
[UnitFriendlyName("Color.Get Cyan")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetCyan : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.cyan;
    }
}
