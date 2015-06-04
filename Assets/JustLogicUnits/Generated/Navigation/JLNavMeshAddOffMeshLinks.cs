using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Add Off Mesh Links")]
[UnitFriendlyName("NavMesh.Add Off Mesh Links")]
public class JLNavMeshAddOffMeshLinks : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        NavMesh.AddOffMeshLinks();
        return null;
    }
}
