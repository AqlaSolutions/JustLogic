using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Request User Authorization")]
[UnitFriendlyName("Request User Authorization")]
[UnitUsage(typeof(UnityEngine.AsyncOperation))]
public class JLAppRequestUserAuthorization : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.UserAuthorization))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.RequestUserAuthorization(Mode.GetResult<UnityEngine.UserAuthorization>(context));
    }
}
