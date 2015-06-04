using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Toggle")]
[UnitFriendlyName("GUI.Toggle")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiToggle : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.Toggle(Position.GetResult<Rect>(context), Value.GetResult<System.Boolean>(context), Text.GetResult<System.String>(context));
    }
}
