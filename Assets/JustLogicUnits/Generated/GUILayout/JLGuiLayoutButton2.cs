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

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.Button(Text.GetResult<System.String>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
