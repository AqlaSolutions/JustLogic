using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginHorizontal")]
[UnitFriendlyName("GUILayout.BeginHorizontal")]
public class JLGuiLayoutBeginHorizontal : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUILayout.BeginHorizontal(Options.GetResult<UnityEngine.GUILayoutOption>(context));
        return null;
    }
}
