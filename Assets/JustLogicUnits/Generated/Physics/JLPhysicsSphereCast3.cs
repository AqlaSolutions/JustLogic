using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Sphere Cast")]
[UnitFriendlyName("Sphere Cast")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsSphereCast3 : JLExpression
{
    [Parameter(ExpressionType = typeof(Ray))]
    public JLExpression Ray;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Radius;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.SphereCast(Ray.GetResult<Ray>(context), Radius.GetResult<System.Single>(context), Distance.GetResult<System.Single>(context), LayerMask);
    }
}
