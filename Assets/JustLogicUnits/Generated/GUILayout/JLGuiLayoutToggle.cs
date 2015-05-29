using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Toggle")]
[UnitFriendlyName("GUILayout.Toggle")]
[UnitUsage(typeof(System.Boolean))]
public class JLGuiLayoutToggle : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Text;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.Toggle(Value.GetResult<System.Boolean>(context), Text.GetResult<System.String>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
