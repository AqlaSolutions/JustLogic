using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/HorizontalScrollbar")]
[UnitFriendlyName("GUILayout.HorizontalScrollbar")]
[UnitUsage(typeof(System.Single))]
public class JLGuiLayoutHorizontalScrollbar : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Size;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression LeftValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression RightValue;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.HorizontalScrollbar(Value.GetResult<System.Single>(context), Size.GetResult<System.Single>(context), LeftValue.GetResult<System.Single>(context), RightValue.GetResult<System.Single>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
