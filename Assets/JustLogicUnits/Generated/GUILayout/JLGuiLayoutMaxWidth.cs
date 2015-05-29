using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/MaxWidth")]
[UnitFriendlyName("GUILayout.MaxWidth")]
[UnitUsage(typeof(UnityEngine.GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutMaxWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxWidth;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.MaxWidth(MaxWidth.GetResult<System.Single>(context));
    }
}
