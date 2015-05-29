using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/EndVertical")]
[UnitFriendlyName("GUILayout.EndVertical")]
public class JLGuiLayoutEndVertical : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUILayout.EndVertical();
        return null;
    }
}
