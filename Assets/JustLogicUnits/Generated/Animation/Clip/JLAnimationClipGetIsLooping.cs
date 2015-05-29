/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Is Looping")]
[UnitFriendlyName("AnimationClip.Get Is Looping")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimationClipGetIsLooping : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.isLooping;
    }
}
*/