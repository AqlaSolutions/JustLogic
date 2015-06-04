using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Default Clip")]
[UnitFriendlyName("Animation.Get Default Clip")]
[UnitUsage(typeof(AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationGetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.clip;
    }
}
