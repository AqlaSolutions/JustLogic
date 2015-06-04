using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/RepeatButton Advanced")]
[UnitFriendlyName("GUI.RepeatButton")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiRepeatButton2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression Image;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.RepeatButton(Position.GetResult<Rect>(context), Image.GetResult<Texture>(context));
    }
}
