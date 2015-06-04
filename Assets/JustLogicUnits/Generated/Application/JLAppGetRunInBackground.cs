using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Run In Background")]
[UnitFriendlyName("Get Run In Background")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetRunInBackground : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.runInBackground;
    }
}
