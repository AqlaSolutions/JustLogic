using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Angle")]
[UnitFriendlyName("Angle")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionAngle : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.Angle(A.GetResult<UnityEngine.Quaternion>(context), B.GetResult<UnityEngine.Quaternion>(context));
    }
}
