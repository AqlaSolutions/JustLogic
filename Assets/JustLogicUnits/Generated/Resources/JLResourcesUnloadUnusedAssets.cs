using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Unload Unused Assets")]
[UnitFriendlyName("Resources.Unload Unused Assets")]
[UnitUsage(typeof(UnityEngine.AsyncOperation))]
public class JLResourcesUnloadUnusedAssets : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.Resources.UnloadUnusedAssets();
    }
}
