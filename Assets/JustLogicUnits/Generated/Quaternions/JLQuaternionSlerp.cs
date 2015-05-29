using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Slerp")]
[UnitFriendlyName("Slerp")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSlerp : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression From;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression To;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression T;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.Slerp(From.GetResult<UnityEngine.Quaternion>(context), To.GetResult<UnityEngine.Quaternion>(context), T.GetResult<System.Single>(context));
    }
}
