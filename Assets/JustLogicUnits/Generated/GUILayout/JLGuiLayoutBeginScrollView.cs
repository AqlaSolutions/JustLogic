using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginScrollView")]
[UnitFriendlyName("GUILayout.BeginScrollView")]
[UnitUsage(typeof(UnityEngine.Vector2))]
public class JLGuiLayoutBeginScrollView : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector2))]
    public JLExpression ScrollPosition;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.BeginScrollView(ScrollPosition.GetResult<UnityEngine.Vector2>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
