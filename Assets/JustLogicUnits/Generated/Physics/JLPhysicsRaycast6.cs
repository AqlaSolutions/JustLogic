using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Raycast")]
[UnitFriendlyName("Raycast")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsRaycast6 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Ray))]
    public JLExpression Ray;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Distance;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.Raycast(Ray.GetResult<UnityEngine.Ray>(context), Distance.GetResult<System.Single>(context), LayerMask);
    }
}
