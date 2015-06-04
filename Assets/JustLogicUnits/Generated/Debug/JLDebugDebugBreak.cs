using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Debug Break")]
[UnitFriendlyName("Debug Break")]
public class JLDebugDebugBreak : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Debug.DebugBreak();
        return null;
    }
}
