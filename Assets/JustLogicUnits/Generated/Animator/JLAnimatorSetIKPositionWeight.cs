using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKPosition Weight")]
[UnitFriendlyName("Animator.Set IKPosition Weight")]
public class JLAnimatorSetIKPositionWeight : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(AvatarIKGoal))]
    public JLExpression Goal;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetIKPositionWeight(Goal.GetResult<AvatarIKGoal>(context), Value.GetResult<System.Single>(context));
        return null;
    }
}
