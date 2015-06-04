using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set Z")]
[UnitFriendlyName("Set Z")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionSetZ : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = Target.GetResult<Quaternion>(context);
        return opValue.z = Value.GetResult<System.Single>(context);
    }
}
