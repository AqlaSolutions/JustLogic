using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Level/Get Count")]
[UnitFriendlyName("Get Level Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAppGetLevelCount : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.levelCount;
    }
}
