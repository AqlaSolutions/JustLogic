using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/BeginArea")]
[UnitFriendlyName("GUILayout.BeginArea")]
public class JLGuiLayoutBeginArea : JLAction
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression ScreenRect;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.BeginArea(ScreenRect.GetResult<Rect>(context));
        return null;
    }
}
