using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Sample Animation")]
[UnitFriendlyName("Sample Animation")]
public class JLGameObjectSampleAnimation : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.GameObject))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AnimationClip))]
    public JLExpression Animation;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Time;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.GameObject opValue = OperandValue.GetResult<UnityEngine.GameObject>(context);
        Animation.GetResult<UnityEngine.AnimationClip>(context).SampleAnimation(opValue, Time.GetResult<System.Single>(context));
        return null;    }
}
