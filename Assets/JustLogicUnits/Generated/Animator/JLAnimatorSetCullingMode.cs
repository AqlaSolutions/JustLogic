using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Culling Mode")]
[UnitFriendlyName("Animator.Set Culling Mode")]
[UnitUsage(typeof(UnityEngine.AnimatorCullingMode))]
public class JLAnimatorSetCullingMode : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AnimatorCullingMode))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.cullingMode = Value.GetResult<UnityEngine.AnimatorCullingMode>(context);
    }
}
