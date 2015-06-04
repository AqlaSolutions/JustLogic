using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Input/Reset Input Axes")]
[UnitFriendlyName("Reset Input Axes")]
public class JLInputResetInputAxes : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Input.ResetInputAxes();
        return null;
    }
}
