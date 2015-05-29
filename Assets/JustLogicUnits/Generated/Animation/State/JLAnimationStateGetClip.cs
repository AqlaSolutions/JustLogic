using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Clip")]
[UnitFriendlyName("AnimationState.Get Clip")]
[UnitUsage(typeof(UnityEngine.AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationStateGetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.clip;
    }
}
