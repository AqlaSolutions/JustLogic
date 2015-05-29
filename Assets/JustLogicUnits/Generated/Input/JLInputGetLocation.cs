using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Location")]
[UnitFriendlyName("Get Location")]
[UnitUsage(typeof(UnityEngine.LocationService), HideExpressionInActionsList = true)]
public class JLInputGetLocation : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Input.location;
    }
}
