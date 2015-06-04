using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Box")]
[UnitFriendlyName("GUILayout.Box")]
public class JLGuiLayoutBox : JLAction
{
    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.Box("", Options.GetResult<GUILayoutOption>(context));
        return null;
    }
}
