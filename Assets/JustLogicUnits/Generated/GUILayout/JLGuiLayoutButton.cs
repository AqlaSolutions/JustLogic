using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Button (Image)")]
[UnitFriendlyName("GUILayout.Button")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutButton : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression Image;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.Button(Image.GetResult<UnityEngine.Texture>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
