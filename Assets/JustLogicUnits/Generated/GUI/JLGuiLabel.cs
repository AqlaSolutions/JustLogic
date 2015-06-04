using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Label")]
[UnitFriendlyName("GUI.Label")]
public class JLGuiLabel : JLAction
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUI.Label(Position.GetResult<Rect>(context), Text.GetResult<System.String>(context));
        return null;
    }
}
