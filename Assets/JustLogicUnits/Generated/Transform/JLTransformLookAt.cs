using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Look At")]
[UnitFriendlyName("Look At")]
public class JLTransformLookAt : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.Transform))]
    public JLExpression Target;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Transform opValue = OperandValue.GetResult<UnityEngine.Transform>(context);
        opValue.LookAt(Target.GetResult<UnityEngine.Transform>(context));
        return null;    }
}
