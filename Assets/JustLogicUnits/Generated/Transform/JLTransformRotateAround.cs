using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Rotate Around")]
[UnitFriendlyName("Rotate Around")]
public class JLTransformRotateAround : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Point;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Axis;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Angle;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        opValue.RotateAround(Point.GetResult<Vector3>(context), Axis.GetResult<Vector3>(context), Angle.GetResult<System.Single>(context));
        return null;    }
}
