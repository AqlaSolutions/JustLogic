using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set X")]
[UnitFriendlyName("Set X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionSetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression Target;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = Target.GetResult<Quaternion>(context);
        return opValue.x = Value.GetResult<System.Single>(context);
    }
}
