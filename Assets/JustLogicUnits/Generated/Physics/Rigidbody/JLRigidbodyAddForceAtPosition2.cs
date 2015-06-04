using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Add Force At Position (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add Force At Position")]
public class JLRigidbodyAddForceAtPosition2 : JLAction
{
    [Parameter(ExpressionType = typeof(Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Force;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(ForceMode))]
    public JLExpression Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Rigidbody opValue = OperandValue.GetResult<Rigidbody>(context);
        opValue.AddForceAtPosition(Force.GetResult<Vector3>(context), Position.GetResult<Vector3>(context), Mode.GetResult<ForceMode>(context));
        return null;
    }
}
