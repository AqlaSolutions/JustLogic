using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/New Rect")]
[UnitFriendlyName("Rect.New Rect")]
[UnitUsage(typeof(Rect), HideExpressionInActionsList = true)]
public class JLRectNewRect : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Source;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new Rect(Source.GetResult<Rect>(context));
    }
}
