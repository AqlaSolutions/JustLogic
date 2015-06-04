using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginScrollView")]
[UnitFriendlyName("GUILayout.BeginScrollView")]
[UnitUsage(typeof(Vector2))]
public class JLGuiLayoutBeginScrollView : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector2))]
    public JLExpression ScrollPosition;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.BeginScrollView(ScrollPosition.GetResult<Vector2>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
