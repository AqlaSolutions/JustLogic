using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Get Gyro")]
[UnitFriendlyName("Get Gyro")]
[UnitUsage(typeof(Gyroscope), HideExpressionInActionsList = true)]
public class JLInputGetGyro : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Input.gyro;
    }
}
