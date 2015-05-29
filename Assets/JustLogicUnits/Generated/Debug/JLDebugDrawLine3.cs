using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Draw Line")]
[UnitFriendlyName("Draw Line")]
public class JLDebugDrawLine3 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Start;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression End;

    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression Color;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Duration;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Debug.DrawLine(Start.GetResult<UnityEngine.Vector3>(context), End.GetResult<UnityEngine.Vector3>(context), Color.GetResult<UnityEngine.Color>(context), Duration.GetResult<System.Single>(context));
        return null;
    }
}
