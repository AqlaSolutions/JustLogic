using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Layers Affect Mass Center")]
[UnitFriendlyName("Animator.Set Layers Affect Mass Center")]
[UnitUsage(typeof(System.Boolean))]
public class JLAnimatorSetLayersAffectMassCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        return opValue.layersAffectMassCenter = Value.GetResult<System.Boolean>(context);
    }
}
