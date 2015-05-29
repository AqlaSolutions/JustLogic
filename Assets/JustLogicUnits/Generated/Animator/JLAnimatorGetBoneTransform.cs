using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Get Bone Transform")]
[UnitFriendlyName("Animator.Get Bone Transform")]
[UnitUsage(typeof(UnityEngine.Transform), HideExpressionInActionsList = true)]
public class JLAnimatorGetBoneTransform : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(UnityEngine.HumanBodyBones))]
    public JLExpression HumanBoneId;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.GetBoneTransform(HumanBoneId.GetResult<UnityEngine.HumanBodyBones>(context));
    }
}
