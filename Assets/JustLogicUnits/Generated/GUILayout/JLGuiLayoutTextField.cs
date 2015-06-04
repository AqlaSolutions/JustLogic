using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/TextField")]
[UnitFriendlyName("GUILayout.TextField")]
[UnitUsage(typeof(System.String))]
public class JLGuiLayoutTextField : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.TextField(Text.GetResult<System.String>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
