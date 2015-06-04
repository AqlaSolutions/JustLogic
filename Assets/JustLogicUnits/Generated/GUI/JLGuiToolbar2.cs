using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Toolbar With Images")]
[UnitFriendlyName("GUI.Toolbar With Images")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiToolbar2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression[] Images;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.Toolbar(Position.GetResult<Rect>(context), Selected.GetResult<System.Int32>(context), Images.GetResult<Texture>(context));
    }
}
