using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Op Inequality")]
[UnitFriendlyName("Rect.Op Inequality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRectOpInequality : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<UnityEngine.Rect>(context) != Rhs.GetResult<UnityEngine.Rect>(context);
    }
}
