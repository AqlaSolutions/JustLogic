using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Quaternion/Angle Axis")]
[UnitFriendlyName("Angle Axis")]
[UnitUsage(typeof(UnityEngine.Quaternion), HideExpressionInActionsList = true)]
public class JLQuaternionAngleAxis : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Angle;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Axis;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Quaternion.AngleAxis(Angle.GetResult<System.Single>(context), Axis.GetResult<UnityEngine.Vector3>(context));
    }
}
