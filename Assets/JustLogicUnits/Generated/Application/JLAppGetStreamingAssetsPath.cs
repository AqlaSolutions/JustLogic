using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Streaming Assets Path")]
[UnitFriendlyName("Get Streaming Assets Path")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetStreamingAssetsPath : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.streamingAssetsPath;
    }
}
