using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Lerp (Color32)")]
[UnitFriendlyName("Color32.Lerp")]
[UnitUsage(typeof(UnityEngine.Color32), HideExpressionInActionsList = true)]
public class JLColor32Lerp : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color32))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Color32))]
    public JLExpression B;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Color32.Lerp(A.GetResult<UnityEngine.Color32>(context), B.GetResult<UnityEngine.Color32>(context), T.GetResult<System.Single>(context));
    }
}
