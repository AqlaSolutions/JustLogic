using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Op Multiply")]
[UnitFriendlyName("Op Multiply")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionOpMultiply : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<Quaternion>(context) * Rhs.GetResult<Quaternion>(context);
    }
}
