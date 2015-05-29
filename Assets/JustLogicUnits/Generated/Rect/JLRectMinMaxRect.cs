using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Min Max Rect")]
[UnitFriendlyName("Rect.Min Max Rect")]
[UnitUsage(typeof(UnityEngine.Rect), HideExpressionInActionsList = true)]
public class JLRectMinMaxRect : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Left;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Top;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Right;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Bottom;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Rect.MinMaxRect(Left.GetResult<System.Single>(context), Top.GetResult<System.Single>(context), Right.GetResult<System.Single>(context), Bottom.GetResult<System.Single>(context));
    }
}
