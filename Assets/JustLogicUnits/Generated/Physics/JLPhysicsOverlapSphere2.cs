using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Overlap Sphere")]
[UnitFriendlyName("Overlap Sphere")]
[UnitUsage(typeof(Collider[]), HideExpressionInActionsList = true)]
public class JLPhysicsOverlapSphere2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Radius;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.OverlapSphere(Position.GetResult<Vector3>(context), Radius.GetResult<System.Single>(context), LayerMask);
    }
}
