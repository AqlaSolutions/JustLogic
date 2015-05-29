using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Unload Asset")]
[UnitFriendlyName("Resources.Unload Asset")]
public class JLResourcesUnloadAsset : JLAction
{
    [Parameter(ExpressionType = typeof(UnityEngine.Object))]
    public JLExpression AssetToUnload;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        UnityEngine.Resources.UnloadAsset(AssetToUnload.GetResult<UnityEngine.Object>(context));
        return null;
    }
}
