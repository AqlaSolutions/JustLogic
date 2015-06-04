using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Rewind Clip")]
[UnitFriendlyName("Animation.Rewind Clip")]
public class JLAnimationRewind2 : JLAction
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        opValue.Rewind(Name.GetResult<System.String>(context));
        return null;
    }
}
