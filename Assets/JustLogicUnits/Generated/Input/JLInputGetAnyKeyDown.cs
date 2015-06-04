using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Any Key Down")]
[UnitFriendlyName("Get Any Key Down")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetAnyKeyDown : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.anyKeyDown;
    }
}
