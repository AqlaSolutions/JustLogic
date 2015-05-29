//using JustLogic.Core;
//using System.Collections.Generic;
//using UnityEngine;

//[UnitMenu("Animator/Get Current Animation Clip State")]
//[UnitFriendlyName("Animator.Get Current Animation Clip State")]
//[UnitUsage(typeof(AnimatorClipInfo[]), HideExpressionInActionsList = true)]
//public class JLAnimatorGetCurrentAnimationClipState : JLExpression
//{
//    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
//    public JLExpression OperandValue;

//    [Parameter(ExpressionType = typeof(System.Int32))]
//    public JLExpression LayerIndex;

//    public override object GetAnyResult(IExecutionContext context)
//    {
//        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
//        return opValue.GetCurrentAnimatorClipInfo(LayerIndex.GetResult<System.Int32>(context));
//    }
//}
