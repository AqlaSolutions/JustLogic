using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKPosition Weight")]
[UnitFriendlyName("Animator.Set IKPosition Weight")]
public class JLAnimatorSetIKPositionWeight : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetIKPositionWeight(Goal.GetResult<UnityEngine.AvatarIKGoal>(context), Value.GetResult<System.Single>(context));
        return null;
    }
}
