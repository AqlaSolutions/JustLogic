using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/ExpandWidth")]
[UnitFriendlyName("GUILayout.ExpandWidth")]
[UnitUsage(typeof(GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutExpandWidth : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Expand;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.ExpandWidth(Expand.GetResult<System.Boolean>(context));
    }
}
