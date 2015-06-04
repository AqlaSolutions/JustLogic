using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/PasswordField")]
[UnitFriendlyName("GUILayout.PasswordField")]
[UnitUsage(typeof(System.String))]
public class JLGuiLayoutPasswordField : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Password;

    [Parameter(ExpressionType = typeof(System.Char))]
    public JLExpression MaskChar;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.PasswordField(Password.GetResult<System.String>(context), MaskChar.GetResult<System.Char>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
