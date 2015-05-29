using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/HorizontalScrollbar")]
[UnitFriendlyName("GUI.HorizontalScrollbar")]
[UnitUsage(typeof(System.Single))]
public class JLGuiHorizontalScrollbar : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Size;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression LeftValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression RightValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.HorizontalScrollbar(Position.GetResult<UnityEngine.Rect>(context), Value.GetResult<System.Single>(context), Size.GetResult<System.Single>(context), LeftValue.GetResult<System.Single>(context), RightValue.GetResult<System.Single>(context));
    }
}
