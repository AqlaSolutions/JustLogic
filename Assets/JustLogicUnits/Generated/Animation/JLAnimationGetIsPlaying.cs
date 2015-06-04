using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Is Playing")]
[UnitFriendlyName("Animation.Get Is Playing")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimationGetIsPlaying : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.isPlaying;
    }
}
