using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Target Frame Rate")]
[UnitFriendlyName("Get Target Frame Rate")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAppGetTargetFrameRate : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.targetFrameRate;
    }
}
