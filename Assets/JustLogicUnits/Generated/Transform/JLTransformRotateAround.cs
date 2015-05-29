using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Rotate Around")]
[UnitFriendlyName("Rotate Around")]
public class JLTransformRotateAround : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Point;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Axis;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Angle;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        opValue.RotateAround(Point.GetResult<UnityEngine.Vector3>(context), Axis.GetResult<UnityEngine.Vector3>(context), Angle.GetResult<System.Single>(context));
        return null;    }
}
