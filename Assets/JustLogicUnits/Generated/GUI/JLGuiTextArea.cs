using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/TextArea")]
[UnitFriendlyName("GUI.TextArea")]
[UnitUsage(typeof(System.String))]
public class JLGuiTextArea : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.TextArea(Position.GetResult<Rect>(context), Text.GetResult<System.String>(context));
    }
}
