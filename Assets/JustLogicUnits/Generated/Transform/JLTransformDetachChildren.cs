using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Transform/Detach Children")]
[UnitFriendlyName("Detach Children")]
public class JLTransformDetachChildren : JLAction
{
    [Parameter(ExpressionType = typeof(Transform))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Transform opValue = OperandValue.GetResult<Transform>(context);
        opValue.DetachChildren();
        return null;    }
}
