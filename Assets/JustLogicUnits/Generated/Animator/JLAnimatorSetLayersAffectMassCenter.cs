using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Layers Affect Mass Center")]
[UnitFriendlyName("Animator.Set Layers Affect Mass Center")]
[UnitUsage(typeof(System.Boolean))]
public class JLAnimatorSetLayersAffectMassCenter : JLExpression
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        return opValue.layersAffectMassCenter = Value.GetResult<System.Boolean>(context);
    }
}
