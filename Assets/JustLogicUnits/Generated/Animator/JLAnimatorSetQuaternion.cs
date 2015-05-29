/*using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animator/Set Quaternion")]
[UnitFriendlyName("Animator.Set Quaternion")]
public class JLAnimatorSetQuaternion : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Animator))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    [Parameter(ExpressionType = typeof(UnityEngine.Quaternion))]
    public JLExpression Value;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Animator opValue = OperandValue.GetResult<UnityEngine.Animator>(context);
        opValue.SetQuaternion(Name.GetResult<System.String>(context), Value.GetResult<UnityEngine.Quaternion>(context));
        return null;
    }
}
*/