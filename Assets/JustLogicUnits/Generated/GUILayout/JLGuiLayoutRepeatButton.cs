using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/RepeatButton (Image)")]
[UnitFriendlyName("GUILayout.RepeatButton")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutRepeatButton : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression Image;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.RepeatButton(Image.GetResult<UnityEngine.Texture>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
