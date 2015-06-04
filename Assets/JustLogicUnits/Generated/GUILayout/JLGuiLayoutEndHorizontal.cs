using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/EndHorizontal")]
[UnitFriendlyName("GUILayout.EndHorizontal")]
public class JLGuiLayoutEndHorizontal : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.EndHorizontal();
        return null;
    }
}
