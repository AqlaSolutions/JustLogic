using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Cross Fade")]
[UnitFriendlyName("Animation.Cross Fade")]
public class JLAnimationCrossFade : JLAction
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        opValue.CrossFade(Animation.GetResult<System.String>(context));
        return null;
    }
}
