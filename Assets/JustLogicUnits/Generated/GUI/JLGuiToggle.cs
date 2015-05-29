using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Toggle")]
[UnitFriendlyName("GUI.Toggle")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiToggle : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.Toggle(Position.GetResult<UnityEngine.Rect>(context), Value.GetResult<System.Boolean>(context), Text.GetResult<System.String>(context));
    }
}
