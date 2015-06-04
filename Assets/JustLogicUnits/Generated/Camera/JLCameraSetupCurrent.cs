using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Setup Current")]
[UnitFriendlyName("Camera.Setup Current")]
public class JLCameraSetupCurrent : JLAction
{
    [Parameter(ExpressionType = typeof(Camera))]
    public JLExpression Cur;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Camera.SetupCurrent(Cur.GetResult<Camera>(context));
        return null;
    }
}
