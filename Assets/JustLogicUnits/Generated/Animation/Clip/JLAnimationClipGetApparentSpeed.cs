/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Apparent Speed")]
[UnitFriendlyName("AnimationClip.Get Apparent Speed")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLAnimationClipGetApparentSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.apparentSpeed;
    }
}
*/