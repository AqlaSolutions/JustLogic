using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/TextField")]
[UnitFriendlyName("GUI.TextField")]
[UnitUsage(typeof(System.String))]
public class JLGuiTextField : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.TextField(Position.GetResult<UnityEngine.Rect>(context), Text.GetResult<System.String>(context));
    }
}
