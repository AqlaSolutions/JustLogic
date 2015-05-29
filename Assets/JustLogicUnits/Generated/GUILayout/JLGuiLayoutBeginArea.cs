using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginArea")]
[UnitFriendlyName("GUILayout.BeginArea")]
public class JLGuiLayoutBeginArea : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression ScreenRect;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUILayout.BeginArea(ScreenRect.GetResult<UnityEngine.Rect>(context));
        return null;
    }
}
