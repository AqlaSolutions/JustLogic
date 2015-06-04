using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Capsule Cast")]
[UnitFriendlyName("Capsule Cast")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsCapsuleCast3 : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Point1;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Point2;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Radius;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Direction;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.CapsuleCast(Point1.GetResult<Vector3>(context), Point2.GetResult<Vector3>(context), Radius.GetResult<System.Single>(context), Direction.GetResult<Vector3>(context), Distance.GetResult<System.Single>(context), LayerMask);
    }
}
