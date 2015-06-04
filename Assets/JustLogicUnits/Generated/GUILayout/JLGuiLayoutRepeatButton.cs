using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/RepeatButton (Image)")]
[UnitFriendlyName("GUILayout.RepeatButton")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutRepeatButton : JLExpression
{
    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression Image;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.RepeatButton(Image.GetResult<Texture>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
