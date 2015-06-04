using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Op Inequality")]
[UnitFriendlyName("Op Inequality")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLQuaternionOpInequality : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<Quaternion>(context) != Rhs.GetResult<Quaternion>(context);
    }
}
