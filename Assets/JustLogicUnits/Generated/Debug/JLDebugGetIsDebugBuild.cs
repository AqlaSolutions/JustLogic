using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Get Is Debug Build")]
[UnitFriendlyName("Get Is Debug Build")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLDebugGetIsDebugBuild : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Debug.isDebugBuild;
    }
}
