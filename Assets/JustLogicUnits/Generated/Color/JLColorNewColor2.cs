using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/New Color")]
[UnitFriendlyName("Color.New Color")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorNewColor2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression R;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression G;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression B;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression A;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new Color(R.GetResult<System.Single>(context), G.GetResult<System.Single>(context), B.GetResult<System.Single>(context), A.GetResult<System.Single>(context));
    }
}
