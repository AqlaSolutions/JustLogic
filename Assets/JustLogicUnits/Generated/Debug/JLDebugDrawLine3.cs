using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Debug/Draw Line")]
[UnitFriendlyName("Draw Line")]
public class JLDebugDrawLine3 : JLAction
{
    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Start;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression End;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression Color;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Duration;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Debug.DrawLine(Start.GetResult<Vector3>(context), End.GetResult<Vector3>(context), Color.GetResult<Color>(context), Duration.GetResult<System.Single>(context));
        return null;
    }
}
