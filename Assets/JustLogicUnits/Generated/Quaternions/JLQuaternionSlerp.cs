using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Slerp")]
[UnitFriendlyName("Slerp")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSlerp : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.Slerp(From.GetResult<Quaternion>(context), To.GetResult<Quaternion>(context), T.GetResult<System.Single>(context));
    }
}
