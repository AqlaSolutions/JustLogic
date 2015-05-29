using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Blend Advanced+")]
[UnitFriendlyName("Animation.Blend Advanced+")]
public class JLAnimationBlend3 : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression TargetWeight;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression FadeLength;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        opValue.Blend(Animation.GetResult<System.String>(context), TargetWeight.GetResult<System.Single>(context), FadeLength.GetResult<System.Single>(context));
        return null;
    }
}
