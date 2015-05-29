using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Path/Get Status")]
[UnitFriendlyName("NavMeshPath.Get Status")]
[UnitUsage(typeof(UnityEngine.NavMeshPathStatus), HideExpressionInActionsList = true)]
public class JLNavMeshPathGetStatus : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshPath))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.NavMeshPath opValue = OperandValue.GetResult<UnityEngine.NavMeshPath>(context);
        return opValue.status;
    }
}
