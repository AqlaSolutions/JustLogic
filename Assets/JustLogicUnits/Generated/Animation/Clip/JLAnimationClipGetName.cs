using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Get Name")]
[UnitFriendlyName("AnimationClip.Get Name")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLAnimationClipGetName : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.name;
    }
}
