/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Clip/Clear Curves")]
[UnitFriendlyName("AnimationClip.Clear Curves")]
public class JLAnimationClipClearCurves : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.AnimationClip opValue = OperandValue.GetResult<UnityEngine.AnimationClip>(context);
        opValue.ClearCurves();
        return null;
    }
}
*/