using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Get Local Euler Angles")]
[UnitFriendlyName("Get Local Euler Angles")]
[UnitUsage(typeof(Vector3), HideExpressionInActionsList = true)]
public class JLTransformGetLocalEulerAngles : JLExpression
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        return opValue.localEulerAngles;
    }
}
