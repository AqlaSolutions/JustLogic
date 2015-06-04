using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Get Euler Angles")]
[UnitFriendlyName("Get Euler Angles")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLQuaternionGetEulerAngles : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = OperandValue.GetResult<Quaternion>(context);
        return opValue.eulerAngles;
    }
}
