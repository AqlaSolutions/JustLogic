using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Check Capsule")]
[UnitFriendlyName("Physics.Check Capsule")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsCheckCapsule2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Start;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression End;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Radius;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 Layermask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.CheckCapsule(Start.GetResult<Vector3>(context), End.GetResult<Vector3>(context), Radius.GetResult<System.Single>(context), Layermask);
    }
}
