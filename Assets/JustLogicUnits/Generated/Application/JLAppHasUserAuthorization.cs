using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Has User Authorization")]
[UnitFriendlyName("Has User Authorization")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppHasUserAuthorization : JLExpression
{
    [Parameter(ExpressionType = typeof(UserAuthorization))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.HasUserAuthorization(Mode.GetResult<UserAuthorization>(context));
    }
}
