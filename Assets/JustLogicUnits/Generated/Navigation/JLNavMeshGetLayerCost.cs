using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Get Layer Cost")]
[UnitFriendlyName("NavMesh.Get Layer Cost")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLNavMeshGetLayerCost : JLExpression
{
    [Parameter(OverrideType = ParameterAttribute.OverrideTypes.Layer)]
    public System.Int32 Layer;

    public override object GetAnyResult(IExecutionContext context)
    {
        return NavMesh.GetLayerCost(Layer);
    }
}
