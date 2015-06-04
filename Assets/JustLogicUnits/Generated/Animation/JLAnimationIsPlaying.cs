using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Is Playing")]
[UnitFriendlyName("Animation.Is Playing")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLAnimationIsPlaying : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.IsPlaying(Name.GetResult<System.String>(context));
    }
}
