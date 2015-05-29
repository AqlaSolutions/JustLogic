using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Op Equality")]
[UnitFriendlyName("Rect.Op Equality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLRectOpEquality : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<UnityEngine.Rect>(context) == Rhs.GetResult<UnityEngine.Rect>(context);
    }
}
