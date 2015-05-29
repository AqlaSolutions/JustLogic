/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Set Curve")]
[UnitFriendlyName("AnimationClip.Set Curve")]
public class JLAnimationClipSetCurve : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression RelativePath;

    [Parameter(ExpressionType = typeof(System.Type))]
    public JLExpression Type;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression PropertyName;

    [Parameter(ExpressionType = typeof(UnityEngine.AnimationCurve))]
    public JLExpression Curve;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        opValue.SetCurve(RelativePath.GetResult<System.String>(context), Type.GetResult<System.Type>(context), PropertyName.GetResult<System.String>(context), Curve.GetResult<UnityEngine.AnimationCurve>(context));
        return null;
    }
}
*/