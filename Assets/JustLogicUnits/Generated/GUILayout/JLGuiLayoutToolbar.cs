using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Toolbar")]
[UnitFriendlyName("GUILayout.Toolbar")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiLayoutToolbar : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Texts;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.Toolbar(Selected.GetResult<System.Int32>(context), Texts.GetResult<System.String>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
