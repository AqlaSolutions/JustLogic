using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/FlexibleSpace")]
[UnitFriendlyName("GUILayout.FlexibleSpace")]
public class JLGuiLayoutFlexibleSpace : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.FlexibleSpace();
        return null;
    }
}
