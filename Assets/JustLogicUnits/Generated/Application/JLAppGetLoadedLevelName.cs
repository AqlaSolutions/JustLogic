using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Get Loaded Level Name")]
[UnitFriendlyName("Get Loaded Level Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetLoadedLevelName : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.loadedLevelName;
    }
}
