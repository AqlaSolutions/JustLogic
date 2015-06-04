using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Clip Count")]
[UnitFriendlyName("Animation.Get Clip Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAnimationGetClipCount : JLExpression
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        return opValue.GetClipCount();
    }
}
