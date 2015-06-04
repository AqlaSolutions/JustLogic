using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Rotate Towards")]
[UnitFriendlyName("Rotate Towards")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionRotateTowards : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression MaxDegreesDelta;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.RotateTowards(From.GetResult<Quaternion>(context), To.GetResult<Quaternion>(context), MaxDegreesDelta.GetResult<System.Single>(context));
    }
}
