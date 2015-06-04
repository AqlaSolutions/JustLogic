using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Black")]
[UnitFriendlyName("Color.Get Black")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetBlack : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.black;
    }
}
