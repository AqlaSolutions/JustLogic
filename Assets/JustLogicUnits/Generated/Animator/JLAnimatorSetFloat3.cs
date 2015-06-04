using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Float With Damping")]
[UnitFriendlyName("Animator.Set Float With Damping")]
public class JLAnimatorSetFloat3 : JLAction
{
    [Parameter(ExpressionType = typeof(Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression DampTime;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression DeltaTime;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animator opValue = OperandValue.GetResult<Animator>(context);
        opValue.SetFloat(Name.GetResult<System.String>(context), Value.GetResult<System.Single>(context), DampTime.GetResult<System.Single>(context), DeltaTime.GetResult<System.Single>(context));
        return null;
    }
}
