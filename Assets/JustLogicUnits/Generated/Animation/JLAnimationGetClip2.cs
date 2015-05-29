using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Get Clip")]
[UnitFriendlyName("Animation.Get Clip")]
[UnitUsage(typeof(UnityEngine.AnimationClip), HideExpressionInActionsList = true)]
public class JLAnimationGetClip2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animation opValue = OperandValue.GetResult<UnityEngine.Animation>(context);
        return opValue.GetClip(Name.GetResult<System.String>(context));
    }
}
