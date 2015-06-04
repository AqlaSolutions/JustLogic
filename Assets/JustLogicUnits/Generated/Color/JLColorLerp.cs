using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Lerp")]
[UnitFriendlyName("Color.Lerp")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorLerp : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression B;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Color.Lerp(A.GetResult<Color>(context), B.GetResult<Color>(context), T.GetResult<System.Single>(context));
    }
}
