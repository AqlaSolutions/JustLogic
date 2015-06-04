using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Angle")]
[UnitFriendlyName("Angle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionAngle : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Angle(A.GetResult<Quaternion>(context), B.GetResult<Quaternion>(context));
    }
}
