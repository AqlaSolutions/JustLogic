using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Path/Get Status")]
[UnitFriendlyName("NavMeshPath.Get Status")]
[UnitUsage(typeof(NavMeshPathStatus), HideExpressionInActionsList = true)]
public class JLNavMeshPathGetStatus : JLExpression
{
    [Parameter(ExpressionType = typeof(NavMeshPath))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        NavMeshPath opValue = OperandValue.GetResult<NavMeshPath>(context);
        return opValue.status;
    }
}
