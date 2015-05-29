/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Ensure Quaternion Continuity")]
[UnitFriendlyName("AnimationClip.Ensure Quaternion Continuity")]
public class JLAnimationClipEnsureQuaternionContinuity : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        opValue.EnsureQuaternionContinuity();
        return null;
    }
}
*/