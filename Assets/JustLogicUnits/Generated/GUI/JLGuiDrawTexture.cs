using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/DrawTexture")]
[UnitFriendlyName("GUI.DrawTexture")]
public class JLGuiDrawTexture : JLAction
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression Image;

    [Parameter(ExpressionType = typeof(ScaleMode))]
    public JLExpression ScaleMode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUI.DrawTexture(Position.GetResult<Rect>(context), Image.GetResult<Texture>(context), ScaleMode.GetResult<ScaleMode>(context));
        return null;
    }
}
