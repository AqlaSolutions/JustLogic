using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Blend Advanced")]
[UnitFriendlyName("Animation.Blend Advanced")]
public class JLAnimationBlend2 : JLAction
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression TargetWeight;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        opValue.Blend(Animation.GetResult<System.String>(context), TargetWeight.GetResult<System.Single>(context));
        return null;
    }
}
