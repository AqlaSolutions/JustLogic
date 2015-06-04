using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Sample Animation")]
[UnitFriendlyName("Sample Animation")]
public class JLGameObjectSampleAnimation : JLAction
{
    [Parameter(ExpressionType = typeof(GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AnimationClip))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Time;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        GameObject opValue = OperandValue.GetResult<GameObject>(context);
        Animation.GetResult<AnimationClip>(context).SampleAnimation(opValue, Time.GetResult<System.Single>(context));
        return null;    }
}
