using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/PasswordField")]
[UnitFriendlyName("GUI.PasswordField")]
[UnitUsage(typeof(System.String))]
public class JLGuiPasswordField : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Password;

    [Parameter(ExpressionType = typeof(System.Char))]
    public JLExpression MaskChar;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.PasswordField(Position.GetResult<UnityEngine.Rect>(context), Password.GetResult<System.String>(context), MaskChar.GetResult<System.Char>(context));
    }
}
