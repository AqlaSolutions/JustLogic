using System.Collections.Generic;
using JustLogic.Core;
using UnityEngine;

[UnitMenu("Application/Level/Restart")]
public class JLLoadLevelRestart : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Application.LoadLevel(Application.loadedLevel);
        yield break;
    }
}
