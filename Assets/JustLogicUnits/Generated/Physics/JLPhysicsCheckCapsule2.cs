using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Check Capsule")]
[UnitFriendlyName("Physics.Check Capsule")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsCheckCapsule2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Start;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression End;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Radius;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 Layermask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.CheckCapsule(Start.GetResult<UnityEngine.Vector3>(context), End.GetResult<UnityEngine.Vector3>(context), Radius.GetResult<System.Single>(context), Layermask);
    }
}
