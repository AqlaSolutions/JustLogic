using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Button Advanced")]
[UnitFriendlyName("GUI.Button")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiButton2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression Image;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.Button(Position.GetResult<Rect>(context), Image.GetResult<Texture>(context));
    }
}
