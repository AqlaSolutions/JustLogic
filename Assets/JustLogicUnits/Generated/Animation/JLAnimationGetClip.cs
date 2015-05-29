using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Default Clip")]
[UnitFriendlyName("Animation.Get Default Clip")]
[UnitUsage(typeof(UnityEngine.AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationGetClip : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.clip;
    }
}
