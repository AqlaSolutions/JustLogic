using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/MinWidth")]
[UnitFriendlyName("GUILayout.MinWidth")]
[UnitUsage(typeof(GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutMinWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MinWidth;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.MinWidth(MinWidth.GetResult<System.Single>(context));
    }
}
