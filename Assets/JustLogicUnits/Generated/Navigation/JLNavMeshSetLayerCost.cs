using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Set Layer Cost")]
[UnitFriendlyName("NavMesh.Set Layer Cost")]
public class JLNavMeshSetLayerCost : JLAction
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression Cost;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        NavMesh.SetAreaCost(Layer, Cost.GetResult<System.Single>(context));
        return null;
    }
}
