using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Set From To Rotation")]
[UnitFriendlyName("Set From To Rotation")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionSetFromToRotation : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression FromDirection;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression ToDirection;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Quaternion opValue = OperandValue.GetResult<UnityEngine.Quaternion>(context);
        opValue.SetFromToRotation(FromDirection.GetResult<UnityEngine.Vector3>(context), ToDirection.GetResult<UnityEngine.Vector3>(context));
        return opValue;
    }
}
