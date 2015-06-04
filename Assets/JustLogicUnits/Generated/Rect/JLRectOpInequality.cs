using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Op Inequality")]
[UnitFriendlyName("Rect.Op Inequality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRectOpInequality : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<Rect>(context) != Rhs.GetResult<Rect>(context);
    }
}
