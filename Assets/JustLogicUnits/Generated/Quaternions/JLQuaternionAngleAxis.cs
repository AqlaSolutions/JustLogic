using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Angle Axis")]
[UnitFriendlyName("Angle Axis")]
[UnitUsage(typeof(Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionAngleAxis : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Angle;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Axis;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Quaternion.AngleAxis(Angle.GetResult<System.Single>(context), Axis.GetResult<Vector3>(context));
    }
}
