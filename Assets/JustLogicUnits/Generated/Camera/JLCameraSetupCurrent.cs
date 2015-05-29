using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Camera/Setup Current")]
[UnitFriendlyName("Camera.Setup Current")]
public class JLCameraSetupCurrent : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Camera))]
    public JLExpression Cur;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Camera.SetupCurrent(Cur.GetResult<UnityEngine.Camera>(context));
        return null;
    }
}
