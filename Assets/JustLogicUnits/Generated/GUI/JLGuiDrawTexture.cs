using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/DrawTexture")]
[UnitFriendlyName("GUI.DrawTexture")]
public class JLGuiDrawTexture : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression Image;

    [Parameter(ExpressionType = typeof(UnityEngine.ScaleMode))]
    public JLExpression ScaleMode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.DrawTexture(Position.GetResult<UnityEngine.Rect>(context), Image.GetResult<UnityEngine.Texture>(context), ScaleMode.GetResult<UnityEngine.ScaleMode>(context));
        return null;
    }
}
