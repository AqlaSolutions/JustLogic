using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/SelectionGrid (Images)")]
[UnitFriendlyName("GUILayout.SelectionGrid")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiLayoutSelectionGrid2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression[] Images;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression XCount;

    [Parameter(ExpressionType = typeof(UnityEngine.GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUILayout.SelectionGrid(Selected.GetResult<System.Int32>(context), Images.GetResult<UnityEngine.Texture>(context), XCount.GetResult<System.Int32>(context), Options.GetResult<UnityEngine.GUILayoutOption>(context));
    }
}
