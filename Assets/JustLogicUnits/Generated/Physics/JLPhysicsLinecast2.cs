using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Linecast")]
[UnitFriendlyName("Linecast")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsLinecast2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Start;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression End;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.LayerMask)]
    public System.Int32 LayerMask = -1;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.Linecast(Start.GetResult<Vector3>(context), End.GetResult<Vector3>(context), LayerMask);
    }
}
