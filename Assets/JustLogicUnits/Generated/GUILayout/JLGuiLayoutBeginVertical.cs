using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginVertical")]
[UnitFriendlyName("GUILayout.BeginVertical")]
public class JLGuiLayoutBeginVertical : JLAction
{
    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.BeginVertical(Options.GetResult<GUILayoutOption>(context));
        return null;
    }
}
