using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Get W")]
[UnitFriendlyName("Get W")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLQuaternionGetW : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = OperandValue.GetResult<Quaternion>(context);
        return opValue.w;
    }
}
