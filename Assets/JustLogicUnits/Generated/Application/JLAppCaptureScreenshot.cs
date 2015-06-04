using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Capture Screenshot")]
[UnitFriendlyName("Capture Screenshot")]
public class JLAppCaptureScreenshot : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Filename;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Application.CaptureScreenshot(Filename.GetResult<System.String>(context));
        return null;    }
}
