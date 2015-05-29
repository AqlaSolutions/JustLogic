using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Raycast All")]
[UnitFriendlyName("Raycast All")]
[UnitUsage(typeof(UnityEngine.RaycastHit[]), HideExpressionInActionsList = true)]
public class JLPhysicsRaycastAll4 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Ray))]
    public JLExpression Ray;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.RaycastAll(Ray.GetResult<UnityEngine.Ray>(context), Distance.GetResult<System.Single>(context), LayerMask);
    }
}
