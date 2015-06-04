using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Box")]
[UnitFriendlyName("GUI.Box")]
public class JLGuiBox : JLAction
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUI.Box(Position.GetResult<Rect>(context), Text.GetResult<System.String>(context));
        return null;
    }
}
