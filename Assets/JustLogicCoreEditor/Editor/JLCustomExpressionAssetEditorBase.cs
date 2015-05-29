#if !JUSTLOGIC_FREE
using JustLogic.Core;
using JustLogic.Editor;
using UnityEditor;

/// <tocexclude />
public class JLCustomExpressionAssetEditorBase : JustLogicExpressionHolderEditor
{
    protected override bool Draw()
    {
        var prevAssetsContainer = JLScriptableHelper.AssetsContainer;
        JLScriptableHelper.AssetsContainer = target;
        try
        {
            return base.Draw();
        }
        finally { JLScriptableHelper.AssetsContainer = prevAssetsContainer; }
    }
}

#endif
