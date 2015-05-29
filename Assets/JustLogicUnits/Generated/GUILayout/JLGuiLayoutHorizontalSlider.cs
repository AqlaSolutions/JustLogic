using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/HorizontalSlider")]
[UnitFriendlyName("GUILayout.HorizontalSlider")]
[UnitUsage(typeof(System.Single))]
public class JLGuiLayoutHorizontalSlider : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression LeftValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression RightValue;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.HorizontalSlider(Value.GetResult<System.Single>(context), LeftValue.GetResult<System.Single>(context), RightValue.GetResult<System.Single>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
