using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Ignore Layer Collision")]
[UnitFriendlyName("Ignore Layer Collision")]
public class JLPhysicsIgnoreLayerCollision2 : JLAction
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer1;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer2;

    [Parameter(ExpressionType = typeof(System.Boolean))]
    public JLExpression Ignore;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Physics.IgnoreLayerCollision(Layer1, Layer2, Ignore.GetResult<System.Boolean>(context));
        return null;
    }
}
