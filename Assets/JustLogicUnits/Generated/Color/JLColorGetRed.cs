using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Red")]
[UnitFriendlyName("Color.Get Red")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetRed : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.red;
    }
}
