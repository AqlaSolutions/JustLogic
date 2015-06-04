using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/SelectionGrid (Images)")]
[UnitFriendlyName("GUI.SelectionGrid")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiSelectionGrid2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(Texture))]
    public JLExpression[] Images;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression XCount;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUI.SelectionGrid(Position.GetResult<Rect>(context), Selected.GetResult<System.Int32>(context), Images.GetResult<Texture>(context), XCount.GetResult<System.Int32>(context));
    }
}
