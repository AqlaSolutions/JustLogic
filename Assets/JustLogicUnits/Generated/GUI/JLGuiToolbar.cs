using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Toolbar")]
[UnitFriendlyName("GUI.Toolbar")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiToolbar : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Texts;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.Toolbar(Position.GetResult<Rect>(context), Selected.GetResult<System.Int32>(context), Texts.GetResult<System.String>(context));
    }
}
