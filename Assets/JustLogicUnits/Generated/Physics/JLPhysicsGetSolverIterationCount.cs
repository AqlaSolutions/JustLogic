using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Get Solver Iteration Count")]
[UnitFriendlyName("Physics.Get Solver Iteration Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLPhysicsGetSolverIterationCount : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.solverIterationCount;
    }
}
