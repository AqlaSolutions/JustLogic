using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Main")]
[UnitFriendlyName("Camera.Get Main")]
[UnitUsage(typeof(Camera), HideExpressionInActionsList = true)]
public class JLCameraGetMain : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Camera.main;
    }
}
