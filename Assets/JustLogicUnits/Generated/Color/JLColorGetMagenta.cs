using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Magenta")]
[UnitFriendlyName("Color.Get Magenta")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetMagenta : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.magenta;
    }
}
