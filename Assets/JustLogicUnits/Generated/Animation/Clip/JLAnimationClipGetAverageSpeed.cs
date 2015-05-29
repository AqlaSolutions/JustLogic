/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Average Speed")]
[UnitFriendlyName("AnimationClip.Get Average Speed")]
[UnitUsage(typeof(UnityEngine.Vector3), HideExpressionInActionsList = true)]
public class JLAnimationClipGetAverageSpeed : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.averageSpeed;
    }
}
*/