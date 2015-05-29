using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Op Multiply")]
[UnitFriendlyName("Op Multiply")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionOpMultiply : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Lhs;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Rhs;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Lhs.GetResult<UnityEngine.Quaternion>(context) * Rhs.GetResult<UnityEngine.Quaternion>(context);
    }
}
