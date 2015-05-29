using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Navigation/Restore Nav Mesh")]
[UnitFriendlyName("NavMesh.Restore Nav Mesh")]
public class JLNavMeshRestoreNavMesh : JLAction
{
    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.NavMesh.RestoreNavMesh();
        return null;
    }
}
