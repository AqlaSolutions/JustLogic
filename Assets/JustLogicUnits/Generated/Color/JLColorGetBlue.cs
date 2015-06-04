using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get Blue")]
[UnitFriendlyName("Color.Get Blue")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorGetBlue : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.blue;
    }
}
