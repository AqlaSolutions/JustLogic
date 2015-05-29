using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/RepeatButton")]
[UnitFriendlyName("GUI.RepeatButton")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiRepeatButton : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.RepeatButton(Position.GetResult<UnityEngine.Rect>(context), Text.GetResult<System.String>(context));
    }
}
