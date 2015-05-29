using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Path/Clear Corners")]
[UnitFriendlyName("NavMeshPath.Clear Corners")]
public class JLNavMeshPathClearCorners : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.NavMeshPath))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.NavMeshPath opValue = OperandValue.GetResult<UnityEngine.NavMeshPath>(context);
        opValue.ClearCorners();
        return null;
    }
}
