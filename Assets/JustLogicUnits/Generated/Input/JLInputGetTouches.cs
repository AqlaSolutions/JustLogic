using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Touches")]
[UnitFriendlyName("Get Touches")]
[UnitUsage(typeof(Touch[]), HideExpressionInActionsList = true)]
public class JLInputGetTouches : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.touches;
    }
}
