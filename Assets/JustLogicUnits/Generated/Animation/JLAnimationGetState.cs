using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get State")]
[UnitFriendlyName("Animation.Get State")]
[UnitUsage(typeof(AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationGetState : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue[Name.GetResult<string>(context)];
    }
}
