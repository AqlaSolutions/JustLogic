using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set IKRotation Weight")]
[UnitFriendlyName("Animator.Set IKRotation Weight")]
public class JLAnimatorSetIKRotationWeight : JLAction
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
        opValue.SetIKRotationWeight(Goal.GetResult<UnityEngine.AvatarIKGoal>(context), Value.GetResult<System.Single>(context));
        return null;
    }
}
