using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Unload Unused Assets")]
[UnitFriendlyName("Resources.Unload Unused Assets")]
[UnitUsage(typeof(AsyncOperation))]
public class JLResourcesUnloadUnusedAssets : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return Resources.UnloadUnusedAssets();
    }
}
