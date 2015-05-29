using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set Look Rotation")]
[UnitFriendlyName("Set Look Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSetLookRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression View;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Quaternion opValue = OperandValue.GetResult<UnityEngine.Quaternion>(context);
        opValue.SetLookRotation(View.GetResult<UnityEngine.Vector3>(context));
        return opValue;
    }
}
