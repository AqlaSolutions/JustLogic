using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Get X")]
[UnitFriendlyName("Get X")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionGetX : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = OperandValue.GetResult<Quaternion>(context);
        return opValue.x;
    }
}
