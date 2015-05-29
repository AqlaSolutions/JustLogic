using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/EndScrollView")]
[UnitFriendlyName("GUILayout.EndScrollView")]
public class JLGuiLayoutEndScrollView : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUILayout.EndScrollView();
        return null;
    }
}
