using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/MinHeight")]
[UnitFriendlyName("GUILayout.MinHeight")]
[UnitUsage(typeof(UnityEngine.GUILayoutOption), HideExpressionInActionsList = true)]
public class JLGuiLayoutMinHeight : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MinHeight;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.MinHeight(MinHeight.GetResult<System.Single>(context));
    }
}
