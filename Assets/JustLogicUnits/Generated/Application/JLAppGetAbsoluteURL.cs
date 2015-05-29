using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Absolute Url")]
[UnitFriendlyName("Get Absolute Url")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetAbsoluteUrl : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.absoluteURL;
    }
}
