using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set Y")]
[UnitFriendlyName("Set Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionSetY : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = Target.GetResult<Quaternion>(context);
        return opValue.y = Value.GetResult<System.Single>(context);
    }
}
