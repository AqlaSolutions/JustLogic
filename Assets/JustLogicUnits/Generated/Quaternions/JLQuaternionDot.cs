using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Dot")]
[UnitFriendlyName("Dot")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionDot : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Dot(A.GetResult<Quaternion>(context), B.GetResult<Quaternion>(context));
    }
}
