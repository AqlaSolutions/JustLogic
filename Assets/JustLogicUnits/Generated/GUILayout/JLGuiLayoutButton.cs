using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Button (Image)")]
[UnitFriendlyName("GUILayout.Button")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutButton : JLExpression
{
    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression Image;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.Button(Image.GetResult<Texture>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
