using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get All Cameras")]
[UnitFriendlyName("Camera.Get All Cameras")]
[UnitUsage(typeof(UnityEngine.Camera[]), HideExpressionInActionsList = true)]
public class JLCameraGetAllCameras : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Camera.allCameras;
    }
}
