using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Compass")]
[UnitFriendlyName("Get Compass")]
[UnitUsage(typeof(UnityEngine.Compass), HideExpressionInActionsList = true)]
public class JLInputGetCompass : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.compass;
    }
}
