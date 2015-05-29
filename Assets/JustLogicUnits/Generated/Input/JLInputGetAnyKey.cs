using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Any Key")]
[UnitFriendlyName("Get Any Key")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLInputGetAnyKey : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.anyKey;
    }
}
