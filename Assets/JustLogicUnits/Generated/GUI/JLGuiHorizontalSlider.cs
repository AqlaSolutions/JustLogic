using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/HorizontalSlider")]
[UnitFriendlyName("GUI.HorizontalSlider")]
[UnitUsage(typeof(System.Single))]
public class JLGuiHorizontalSlider : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression LeftValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression RightValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.HorizontalSlider(Position.GetResult<Rect>(context), Value.GetResult<System.Single>(context), LeftValue.GetResult<System.Single>(context), RightValue.GetResult<System.Single>(context));
    }
}
