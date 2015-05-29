using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Width")]
[UnitFriendlyName("GUILayout.Width")]
[UnitUsage(typeof(UnityEngine.GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Width;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.Width(Width.GetResult<System.Single>(context));
    }
}
