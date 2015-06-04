using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set Look Rotation")]
[UnitFriendlyName("Set Look Rotation")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSetLookRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(Quaternion))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression View;

    public override object GetAnyResult(IExecutionContext context)
    {
        Quaternion opValue = OperandValue.GetResult<Quaternion>(context);
        opValue.SetLookRotation(View.GetResult<Vector3>(context));
        return opValue;
    }
}
