using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get Main")]
[UnitFriendlyName("Camera.Get Main")]
[UnitUsage(typeof(UnityEngine.Camera), HideExpressionInActionsList = true)]
public class JLCameraGetMain : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Camera.main;
    }
}
