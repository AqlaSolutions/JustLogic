using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Request User Authorization")]
[UnitFriendlyName("Request User Authorization")]
[UnitUsage(typeof(AsyncOperation))]
public class JLAppRequestUserAuthorization : JLExpression
{
    [Parameter(ExpressionType = typeof(UserAuthorization))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.RequestUserAuthorization(Mode.GetResult<UserAuthorization>(context));
    }
}
