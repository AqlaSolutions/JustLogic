using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Width")]
[UnitFriendlyName("GUILayout.Width")]
[UnitUsage(typeof(GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Width;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.Width(Width.GetResult<System.Single>(context));
    }
}
