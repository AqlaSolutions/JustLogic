using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Look At Position")]
[UnitFriendlyName("Look At Position")]
public class JLTransformLookAt2 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Vector3))]
    public JLExpression WorldPosition;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        opValue.LookAt(WorldPosition.GetResult<UnityEngine.Vector3>(context));
        return null;    }
}
