using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Mouse Present")]
[UnitFriendlyName("Get Mouse Present")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetMousePresent : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.mousePresent;
    }
}
