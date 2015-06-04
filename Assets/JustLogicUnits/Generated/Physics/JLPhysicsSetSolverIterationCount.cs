using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Set Solver Iteration Count")]
[UnitFriendlyName("Physics.Set Solver Iteration Count")]
[UnitUsage(typeof(System.Int32))]
public class JLPhysicsSetSolverIterationCount : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return Physics.solverIterationCount = Value.GetResult<System.Int32>(context);
    }
}
