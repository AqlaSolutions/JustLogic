using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/State/Get Name")]
[UnitFriendlyName("AnimationState.Get Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAnimationStateGetName : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationState))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationState opValue = OperandValue.GetResult<UnityEngine.AnimationState>(context);
        return opValue.name;
    }
}
