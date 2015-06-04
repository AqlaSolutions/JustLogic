using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Get All Cameras")]
[UnitFriendlyName("Camera.Get All Cameras")]
[UnitUsage(typeof(Camera[]), HideExpressionInActionsList = true)]
public class JLCameraGetAllCameras : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Camera.allCameras;
    }
}
