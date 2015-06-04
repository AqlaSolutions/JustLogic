using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Stop Clip")]
[UnitFriendlyName("Animation.Stop Clip")]
public class JLAnimationStop2 : JLAction
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Name;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        opValue.Stop(Name.GetResult<System.String>(context));
        return null;
    }
}
