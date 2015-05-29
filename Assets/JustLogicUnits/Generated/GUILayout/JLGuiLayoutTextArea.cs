using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/TextArea")]
[UnitFriendlyName("GUILayout.TextArea")]
[UnitUsage(typeof(System.String))]
public class JLGuiLayoutTextArea : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.TextArea(Text.GetResult<System.String>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
