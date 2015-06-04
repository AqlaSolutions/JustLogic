using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Clip")]
[UnitFriendlyName("Animation.Get Clip")]
[UnitUsage(typeof(AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationGetClip2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.GetClip(Name.GetResult<System.String>(context));
    }
}
