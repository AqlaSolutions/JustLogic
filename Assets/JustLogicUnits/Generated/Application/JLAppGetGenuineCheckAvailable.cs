using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Genuine Check Available")]
[UnitFriendlyName("Get Genuine Check Available")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAppGetGenuineCheckAvailable : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.genuineCheckAvailable;
    }
}
