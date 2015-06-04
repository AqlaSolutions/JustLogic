using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Look At")]
[UnitFriendlyName("Look At")]
public class JLTransformLookAt : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression Target;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        opValue.LookAt(Target.GetResult<Transform>(context));
        return null;    }
}
