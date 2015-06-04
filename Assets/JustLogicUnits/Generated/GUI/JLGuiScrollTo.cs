using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/ScrollTo")]
[UnitFriendlyName("GUI.ScrollTo")]
public class JLGuiScrollTo : JLAction
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUI.ScrollTo(Position.GetResult<Rect>(context));
        return null;
    }
}
