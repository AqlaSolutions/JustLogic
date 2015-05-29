using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Web Security Host Url")]
[UnitFriendlyName("Get Web Security Host Url")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetWebSecurityHostUrl : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.webSecurityHostUrl;
    }
}
