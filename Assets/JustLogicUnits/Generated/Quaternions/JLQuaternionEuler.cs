using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Euler")]
[UnitFriendlyName("Euler")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionEuler : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Euler;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Euler(Euler.GetResult<Vector3>(context));
    }
}
