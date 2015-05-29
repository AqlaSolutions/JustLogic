/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Validate If Retargetable")]
[UnitFriendlyName("AnimationClip.Validate If Retargetable")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimationClipValidateIfRetargetable : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression ShowWarning;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        return opValue.ValidateIfRetargetable(ShowWarning.GetResult<System.Boolean>(context));
    }
}
*/