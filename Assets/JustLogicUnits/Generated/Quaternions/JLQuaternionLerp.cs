using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Lerp")]
[UnitFriendlyName("Lerp")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionLerp : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Lerp(From.GetResult<Quaternion>(context), To.GetResult<Quaternion>(context), T.GetResult<System.Single>(context));
    }
}
