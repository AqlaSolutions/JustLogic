using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Has User Authorization")]
[UnitFriendlyName("Has User Authorization")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppHasUserAuthorization : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.UserAuthorization))]
    public JLExpression Mode;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.HasUserAuthorization(Mode.GetResult<UnityEngine.UserAuthorization>(context));
    }
}
