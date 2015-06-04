using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/BeginScrollView")]
[UnitFriendlyName("GUI.BeginScrollView")]
[UnitUsage(typeof(Vector2))]
public class JLGuiBeginScrollView : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression ScrollPosition;

    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression ViewRect;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.BeginScrollView(Position.GetResult<Rect>(context), ScrollPosition.GetResult<Vector2>(context), ViewRect.GetResult<Rect>(context));
    }
}
