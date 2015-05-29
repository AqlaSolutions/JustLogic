using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/New Rect")]
[UnitFriendlyName("Rect.New Rect")]
[UnitUsage(typeof(UnityEngine.Rect), HideExpressionInActionsList = true)]
public class JLRectNewRect : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Source;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.Rect(Source.GetResult<UnityEngine.Rect>(context));
    }
}
