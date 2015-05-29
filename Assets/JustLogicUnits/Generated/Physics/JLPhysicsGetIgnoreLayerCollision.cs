using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Physics/Settings/Get Ignore Layer Collision")]
[UnitFriendlyName("Get Ignore Layer Collision")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLPhysicsGetIgnoreLayerCollision : JLExpression
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer1;

    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer2;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Physics.GetIgnoreLayerCollision(Layer1, Layer2);
    }
}
