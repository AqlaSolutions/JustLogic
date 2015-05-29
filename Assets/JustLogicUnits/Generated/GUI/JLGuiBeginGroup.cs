using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/BeginGroup")]
[UnitFriendlyName("GUI.BeginGroup")]
public class JLGuiBeginGroup : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.BeginGroup(Position.GetResult<UnityEngine.Rect>(context));
        return null;
    }
}
