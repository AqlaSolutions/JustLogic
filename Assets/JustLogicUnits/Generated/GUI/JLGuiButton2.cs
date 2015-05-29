using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/Button Advanced")]
[UnitFriendlyName("GUI.Button")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiButton2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression Image;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.Button(Position.GetResult<UnityEngine.Rect>(context), Image.GetResult<UnityEngine.Texture>(context));
    }
}
