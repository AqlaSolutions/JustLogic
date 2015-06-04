using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Path/Get Corners")]
[UnitFriendlyName("NavMeshPath.Get Corners")]
[UnitUsage(typeof(Vector3[]), HideExpressionInActionsList = true)]
public class JLNavMeshPathGetCorners : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshPath))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshPath opValue = OperandValue.GetResult<NavMeshPath>(context);
        return opValue.corners;
    }
}
