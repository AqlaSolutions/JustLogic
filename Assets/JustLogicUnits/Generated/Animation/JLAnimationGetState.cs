using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get State")]
[UnitFriendlyName("Animation.Get State")]
[UnitUsage(typeof(UnityEngine.AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationGetState : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue[Name.GetResult<string>(context)];
    }
}
