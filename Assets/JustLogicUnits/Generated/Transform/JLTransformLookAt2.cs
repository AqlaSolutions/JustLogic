using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Look At Position")]
[UnitFriendlyName("Look At Position")]
public class JLTransformLookAt2 : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Vector3))]
    public JLExpression WorldPosition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        opValue.LookAt(WorldPosition.GetResult<Vector3>(context));
        return null;    }
}
