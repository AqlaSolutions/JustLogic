using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/EndArea")]
[UnitFriendlyName("GUILayout.EndArea")]
public class JLGuiLayoutEndArea : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.EndArea();
        return null;
    }
}
