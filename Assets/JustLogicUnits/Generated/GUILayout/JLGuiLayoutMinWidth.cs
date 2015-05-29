using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/MinWidth")]
[UnitFriendlyName("GUILayout.MinWidth")]
[UnitUsage(typeof(UnityEngine.GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutMinWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MinWidth;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.MinWidth(MinWidth.GetResult<System.Single>(context));
    }
}
