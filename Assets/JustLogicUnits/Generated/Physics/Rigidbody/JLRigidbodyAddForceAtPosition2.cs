using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Add Force At Position (Rigidbody)")]
[UnitFriendlyName("Rigidbody.Add Force At Position")]
public class JLRigidbodyAddForceAtPosition2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rigidbody))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Force;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(UnityEngine.ForceMode))]
    public JLExpression Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Rigidbody opValue = OperandValue.GetResult<UnityEngine.Rigidbody>(context);
        opValue.AddForceAtPosition(Force.GetResult<UnityEngine.Vector3>(context), Position.GetResult<UnityEngine.Vector3>(context), Mode.GetResult<UnityEngine.ForceMode>(context));
        return null;
    }
}
