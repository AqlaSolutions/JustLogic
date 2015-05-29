using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/VerticalScrollbar")]
[UnitFriendlyName("GUI.VerticalScrollbar")]
[UnitUsage(typeof(System.Single))]
public class JLGuiVerticalScrollbar : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Size;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression TopValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression BottomValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.VerticalScrollbar(Position.GetResult<UnityEngine.Rect>(context), Value.GetResult<System.Single>(context), Size.GetResult<System.Single>(context), TopValue.GetResult<System.Single>(context), BottomValue.GetResult<System.Single>(context));
    }
}
