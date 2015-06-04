using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Device Orientation")]
[UnitFriendlyName("Get Device Orientation")]
[UnitUsage(typeof(DeviceOrientation), HideExpressionInActionsList = true)]
public class JLInputGetDeviceOrientation : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.deviceOrientation;
    }
}
