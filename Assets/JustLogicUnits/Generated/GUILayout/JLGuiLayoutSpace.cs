using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/Space")]
[UnitFriendlyName("GUILayout.Space")]
public class JLGuiLayoutSpace : JLAction
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Pixels;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GUILayout.Space(Pixels.GetResult<System.Single>(context));
        return null;
    }
}
