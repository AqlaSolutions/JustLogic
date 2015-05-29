using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/RepeatButton Advanced")]
[UnitFriendlyName("GUI.RepeatButton")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiRepeatButton2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression Image;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.RepeatButton(Position.GetResult<UnityEngine.Rect>(context), Image.GetResult<UnityEngine.Texture>(context));
    }
}
