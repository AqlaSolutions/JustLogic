using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Cross Fade Advanced")]
[UnitFriendlyName("Animation.Cross Fade Advanced")]
public class JLAnimationCrossFade3 : JLAction
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression FadeLength;

    [Parameter(ExpressionType = typeof(PlayMode))]
    public JLExpression Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        opValue.CrossFade(Animation.GetResult<System.String>(context), FadeLength.GetResult<System.Single>(context), Mode.GetResult<PlayMode>(context));
        return null;
    }
}
