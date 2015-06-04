using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Label")]
[UnitFriendlyName("GUILayout.Label")]
public class JLGuiLayoutLabel : JLAction
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.Label(Text.GetResult<System.String>(context), Options.GetResult<GUILayoutOption>(context));
        return null;
    }
}
