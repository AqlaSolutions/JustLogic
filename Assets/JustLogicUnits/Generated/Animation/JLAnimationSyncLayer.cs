using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Animation/Sync Layer")]
[UnitFriendlyName("Animation.Sync Layer")]
public class JLAnimationSyncLayer : JLAction
{
    [Parameter(ExpressionType = typeof(Animation))]
    public JLExpression OperandValue;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Animation opValue = OperandValue.GetResult<Animation>(context);
        opValue.SyncLayer(Layer);
        return null;
    }
}
