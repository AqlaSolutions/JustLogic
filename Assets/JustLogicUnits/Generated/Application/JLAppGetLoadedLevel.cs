using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Get Loaded Level Index")]
[UnitFriendlyName("Get Loaded Level Index")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAppGetLoadedLevel : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.loadedLevel;
    }
}
