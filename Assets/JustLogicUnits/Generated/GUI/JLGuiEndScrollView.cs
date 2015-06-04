using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/EndScrollView")]
[UnitFriendlyName("GUI.EndScrollView")]
public class JLGuiEndScrollView : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUI.EndScrollView();
        return null;
    }
}
