using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Path/New Nav Mesh Path")]
[UnitFriendlyName("NavMeshPath.New Nav Mesh Path")]
[UnitUsage(typeof(UnityEngine.NavMeshPath), HideExpressionInActionsList = true)]
public class JLNavMeshPathNewNavMeshPath : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return new UnityEngine.NavMeshPath();
    }
}
