using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Culling Mode")]
[UnitFriendlyName("Animator.Set Culling Mode")]
[UnitUsage(typeof(AnimatorCullingMode))]
public class JLAnimatorSetCullingMode : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AnimatorCullingMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.cullingMode = Value.GetResult<AnimatorCullingMode>(context);
    }
}
