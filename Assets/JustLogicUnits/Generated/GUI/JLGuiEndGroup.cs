using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/EndGroup")]
[UnitFriendlyName("GUI.EndGroup")]
public class JLGuiEndGroup : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.EndGroup();
        return null;
    }
}
