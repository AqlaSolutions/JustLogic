using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Object/Resources/Unload Asset")]
[UnitFriendlyName("Resources.Unload Asset")]
public class JLResourcesUnloadAsset : JLAction
{
    [Parameter(ExpressionType = typeof(Object))]
    public JLExpression AssetToUnload;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Resources.UnloadAsset(AssetToUnload.GetResult<Object>(context));
        return null;
    }
}
