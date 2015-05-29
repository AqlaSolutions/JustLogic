using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Application/Quit")]
public class JLQuit : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Application.Quit();
        yield break;
    }
}
