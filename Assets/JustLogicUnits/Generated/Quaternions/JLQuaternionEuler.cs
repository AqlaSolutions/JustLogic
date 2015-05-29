using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Euler")]
[UnitFriendlyName("Euler")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionEuler : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Euler;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.Euler(Euler.GetResult<UnityEngine.Vector3>(context));
    }
}
