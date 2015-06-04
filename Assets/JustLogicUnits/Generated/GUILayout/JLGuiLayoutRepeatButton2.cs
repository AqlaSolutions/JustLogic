using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/RepeatButton")]
[UnitFriendlyName("GUILayout.RepeatButton")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutRepeatButton2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.RepeatButton(Text.GetResult<System.String>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
