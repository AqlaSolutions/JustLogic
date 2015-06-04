using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Name")]
[UnitFriendlyName("AnimationState.Get Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAnimationStateGetName : JLExpression
{
    [Parameter(ExpressionType = typeof(AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        AnimationState opValue = OperandValue.GetResult<AnimationState>(context);
        return opValue.name;
    }
}
