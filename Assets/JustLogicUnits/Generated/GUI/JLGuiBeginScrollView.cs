using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/BeginScrollView")]
[UnitFriendlyName("GUI.BeginScrollView")]
[UnitUsage(typeof(UnityEngine.Vector2))]
public class JLGuiBeginScrollView : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression ScrollPosition;

    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression ViewRect;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.BeginScrollView(Position.GetResult<UnityEngine.Rect>(context), ScrollPosition.GetResult<UnityEngine.Vector2>(context), ViewRect.GetResult<UnityEngine.Rect>(context));
    }
}
