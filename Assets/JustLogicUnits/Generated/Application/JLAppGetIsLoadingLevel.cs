using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Is Loading Level")]
[UnitFriendlyName("Get Is Loading Level")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetIsLoadingLevel : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.isLoadingLevel;
    }
}
