using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/New Rect")]
[UnitFriendlyName("Rect.New Rect")]
[UnitUsage(typeof(Rect), HideExpressionInActionsList = true)]
public class JLRectNewRect2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Left;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Top;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Width;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Height;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new Rect(Left.GetResult<System.Single>(context), Top.GetResult<System.Single>(context), Width.GetResult<System.Single>(context), Height.GetResult<System.Single>(context));
    }
}
