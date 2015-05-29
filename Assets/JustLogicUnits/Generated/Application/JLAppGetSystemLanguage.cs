using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get System Language")]
[UnitFriendlyName("Get System Language")]
[UnitUsage(typeof(UnityEngine.SystemLanguage), HideExpressionInActionsList = true)]
public class JLAppGetSystemLanguage : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Application.systemLanguage;
    }
}
