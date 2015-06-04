using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/TextField")]
[UnitFriendlyName("GUI.TextField")]
[UnitUsage(typeof(System.String))]
public class JLGuiTextField : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.TextField(Position.GetResult<Rect>(context), Text.GetResult<System.String>(context));
    }
}
