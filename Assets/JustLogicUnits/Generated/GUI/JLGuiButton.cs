using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Button")]
[UnitFriendlyName("GUI.Button")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiButton : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.Button(Position.GetResult<UnityEngine.Rect>(context), Text.GetResult<System.String>(context));
    }
}
