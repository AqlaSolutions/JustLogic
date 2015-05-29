using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Label")]
[UnitFriendlyName("GUI.Label")]
public class JLGuiLabel : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GUI.Label(Position.GetResult<UnityEngine.Rect>(context), Text.GetResult<System.String>(context));
        return null;
    }
}
