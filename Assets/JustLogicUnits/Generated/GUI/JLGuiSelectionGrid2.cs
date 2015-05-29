using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/SelectionGrid (Images)")]
[UnitFriendlyName("GUI.SelectionGrid")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiSelectionGrid2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(UnityEngine.Texture))]
    public JLExpression[] Images;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression XCount;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.SelectionGrid(Position.GetResult<UnityEngine.Rect>(context), Selected.GetResult<System.Int32>(context), Images.GetResult<UnityEngine.Texture>(context), XCount.GetResult<System.Int32>(context));
    }
}
