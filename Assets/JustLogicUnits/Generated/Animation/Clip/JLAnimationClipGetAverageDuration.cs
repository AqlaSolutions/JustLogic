/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Average Duration")]
[UnitFriendlyName("AnimationClip.Get Average Duration")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimationClipGetAverageDuration : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.averageDuration;
    }
}
*/