using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Sample")]
[UnitFriendlyName("Animation.Sample")]
public class JLAnimationSample : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        opValue.Sample();
        return null;
    }
}
