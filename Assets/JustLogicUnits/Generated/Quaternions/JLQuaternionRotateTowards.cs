using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Rotate Towards")]
[UnitFriendlyName("Rotate Towards")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionRotateTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDegreesDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.RotateTowards(From.GetResult<UnityEngine.Quaternion>(context), To.GetResult<UnityEngine.Quaternion>(context), MaxDegreesDelta.GetResult<System.Single>(context));
    }
}
