using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Break")]
[UnitFriendlyName("Break")]
public class JLDebugBreak : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Debug.Break();
        return null;
    }
}
