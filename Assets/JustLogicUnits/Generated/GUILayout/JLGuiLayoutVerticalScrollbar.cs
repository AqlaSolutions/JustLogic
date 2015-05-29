using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/VerticalScrollbar")]
[UnitFriendlyName("GUILayout.VerticalScrollbar")]
[UnitUsage(typeof(System.Single))]
public class JLGuiLayoutVerticalScrollbar : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Size;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression TopValue;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression BottomValue;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.VerticalScrollbar(Value.GetResult<System.Single>(context), Size.GetResult<System.Single>(context), TopValue.GetResult<System.Single>(context), BottomValue.GetResult<System.Single>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
