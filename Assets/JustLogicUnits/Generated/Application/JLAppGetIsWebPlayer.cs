using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Is Web Player")]
[UnitFriendlyName("Get Is Web Player")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetIsWebPlayer : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.isWebPlayer;
    }
}
