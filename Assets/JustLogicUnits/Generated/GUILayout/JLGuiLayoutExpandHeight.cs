using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/ExpandHeight")]
[UnitFriendlyName("GUILayout.ExpandHeight")]
[UnitUsage(typeof(UnityEngine.GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutExpandHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Expand;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.ExpandHeight(Expand.GetResult<System.Boolean>(context));
    }
}
