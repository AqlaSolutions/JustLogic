using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/ScrollTo")]
[UnitFriendlyName("GUI.ScrollTo")]
public class JLGuiScrollTo : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.ScrollTo(Position.GetResult<UnityEngine.Rect>(context));
        return null;
    }
}
