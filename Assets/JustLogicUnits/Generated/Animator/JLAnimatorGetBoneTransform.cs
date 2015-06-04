using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Bone Transform")]
[UnitFriendlyName("Animator.Get Bone Transform")]
[UnitUsage(typeof(Transform), HideExpressionInActionsList = true)]
public class JLAnimatorGetBoneTransform : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(HumanBodyBones))]
    public JLExpression HumanBoneId;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.GetBoneTransform(HumanBoneId.GetResult<HumanBodyBones>(context));
    }
}
