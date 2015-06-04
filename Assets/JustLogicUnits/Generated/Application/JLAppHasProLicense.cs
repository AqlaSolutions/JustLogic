using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Has Pro License")]
[UnitFriendlyName("Has Pro License")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppHasProLicense : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.HasProLicense();
    }
}
