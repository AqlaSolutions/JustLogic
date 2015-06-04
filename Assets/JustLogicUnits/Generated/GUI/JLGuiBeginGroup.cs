using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/BeginGroup")]
[UnitFriendlyName("GUI.BeginGroup")]
public class JLGuiBeginGroup : JLAction
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUI.BeginGroup(Position.GetResult<Rect>(context));
        return null;
    }
}
