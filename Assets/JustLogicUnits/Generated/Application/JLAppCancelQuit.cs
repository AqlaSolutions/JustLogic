using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Application/Cancel Quit")]
[UnitFriendlyName("Cancel Quit")]
public class JLAppCancelQuit : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Application.CancelQuit();
        return null;    }
}
