using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Get Internet Reachability")]
[UnitFriendlyName("Get Internet Reachability")]
[UnitUsage(typeof(NetworkReachability), HideExpressionInActionsList = true)]
public class JLAppGetInternetReachability : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Application.internetReachability;
    }
}
