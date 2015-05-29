using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Sphere Cast All")]
[UnitFriendlyName("Sphere Cast All")]
[UnitUsage(typeof(UnityEngine.RaycastHit[]), HideExpressionInActionsList = true)]
public class JLPhysicsSphereCastAll5 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Ray))]
    public JLExpression Ray;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Radius;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.SphereCastAll(Ray.GetResult<UnityEngine.Ray>(context), Radius.GetResult<System.Single>(context), Distance.GetResult<System.Single>(context), LayerMask);
    }
}
