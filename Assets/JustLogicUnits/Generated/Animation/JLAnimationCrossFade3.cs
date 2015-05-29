using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Cross Fade Advanced")]
[UnitFriendlyName("Animation.Cross Fade Advanced")]
public class JLAnimationCrossFade3 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression FadeLength;

    [Parameter(ExpressionType = typeof(UnityEngine.PlayMode))]
    public JLExpression Mode;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        opValue.CrossFade(Animation.GetResult<System.String>(context), FadeLength.GetResult<System.Single>(context), Mode.GetResult<UnityEngine.PlayMode>(context));
        return null;
    }
}
