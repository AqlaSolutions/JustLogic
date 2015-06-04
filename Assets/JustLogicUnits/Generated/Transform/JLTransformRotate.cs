using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Rotate")]
[UnitFriendlyName("Rotate")]
public class JLTransformRotate : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression EulerAngles;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        opValue.Rotate(EulerAngles.GetResult<Vector3>(context));
        return null;    }
}
