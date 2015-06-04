using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Genuine")]
[UnitFriendlyName("Get Genuine")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetGenuine : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.genuine;
    }
}
