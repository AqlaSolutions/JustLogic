using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Get Euler Angles")]
[UnitFriendlyName("Get Euler Angles")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLQuaternionGetEulerAngles : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Quaternion opValue = OperandValue.GetResult<UnityEngine.Quaternion>(context);
        return opValue.eulerAngles;
    }
}
