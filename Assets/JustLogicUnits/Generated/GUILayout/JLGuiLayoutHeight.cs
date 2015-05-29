using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Height")]
[UnitFriendlyName("GUILayout.Height")]
[UnitUsage(typeof(UnityEngine.GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Height;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.Height(Height.GetResult<System.Single>(context));
    }
}
