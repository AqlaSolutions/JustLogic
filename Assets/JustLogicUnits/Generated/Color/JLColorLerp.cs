using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Lerp")]
[UnitFriendlyName("Color.Lerp")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorLerp : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression B;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Color.Lerp(A.GetResult<UnityEngine.Color>(context), B.GetResult<UnityEngine.Color>(context), T.GetResult<System.Single>(context));
    }
}
