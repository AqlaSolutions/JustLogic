using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginVertical")]
[UnitFriendlyName("GUILayout.BeginVertical")]
public class JLGuiLayoutBeginVertical : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUILayout.BeginVertical(Options.GetResult<UnityEngine.GUILayoutOption>(context));
        return null;
    }
}
