using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Unity Version")]
[UnitFriendlyName("Get Unity Version")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAppGetUnityVersion : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.unityVersion;
    }
}
