using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Calculate Path")]
[UnitFriendlyName("NavMesh.Calculate Path")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLNavMeshCalculatePath : JLExpression
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression SourcePosition;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression TargetPosition;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression PassableMask;

    [Parameter(ExpressionType = typeof(NavMeshPath))]
    public JLExpression Path;

    public override object GetAnyResult(IExecutionContext context)
    {
        return NavMesh.CalculatePath(SourcePosition.GetResult<Vector3>(context), TargetPosition.GetResult<Vector3>(context), PassableMask.GetResult<System.Int32>(context), Path.GetResult<NavMeshPath>(context));
    }
}
