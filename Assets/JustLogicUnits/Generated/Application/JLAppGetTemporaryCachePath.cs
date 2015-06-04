using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Temporary Cache Path")]
[UnitFriendlyName("Get Temporary Cache Path")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetTemporaryCachePath : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.temporaryCachePath;
    }
}
