using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Path/Get Corners")]
[UnitFriendlyName("NavMeshPath.Get Corners")]
[UnitUsage(typeof(UnityEngine.Vector3[]), HideExpressionInActionsList = true)]
public class JLNavMeshPathGetCorners : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshPath))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshPath opValue = OperandValue.GetResult<UnityEngine.NavMeshPath>(context);
        return opValue.corners;
    }
}
