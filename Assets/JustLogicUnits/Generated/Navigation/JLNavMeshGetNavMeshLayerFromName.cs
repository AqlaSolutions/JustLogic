using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Get Nav Mesh Layer From Name")]
[UnitFriendlyName("NavMesh.Get Nav Mesh Layer From Name")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLNavMeshGetNavMeshLayerFromName : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression LayerName;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.NavMesh.GetNavMeshLayerFromName(LayerName.GetResult<System.String>(context));
    }
}
