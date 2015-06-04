using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Is Playing")]
[UnitFriendlyName("Get Is Playing")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetIsPlaying : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.isPlaying;
    }
}
