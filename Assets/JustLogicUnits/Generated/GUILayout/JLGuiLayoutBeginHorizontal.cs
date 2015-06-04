using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginHorizontal")]
[UnitFriendlyName("GUILayout.BeginHorizontal")]
public class JLGuiLayoutBeginHorizontal : JLAction
{
    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.BeginHorizontal(Options.GetResult<GUILayoutOption>(context));
        return null;
    }
}
