using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Button")]
[UnitFriendlyName("GUILayout.Button")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutButton2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.Button(Text.GetResult<System.String>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
