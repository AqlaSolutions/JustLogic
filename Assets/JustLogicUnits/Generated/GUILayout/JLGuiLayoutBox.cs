using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Box")]
[UnitFriendlyName("GUILayout.Box")]
public class JLGuiLayoutBox : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUILayout.Box("", Options.GetResult<UnityEngine.GUILayoutOption>(context));
        return null;
    }
}
