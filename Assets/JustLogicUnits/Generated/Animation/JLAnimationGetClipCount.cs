using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Clip Count")]
[UnitFriendlyName("Animation.Get Clip Count")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLAnimationGetClipCount : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.GetClipCount();
    }
}
