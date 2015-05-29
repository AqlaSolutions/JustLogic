using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUI/SelectionGrid")]
[UnitFriendlyName("GUI.SelectionGrid")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiSelectionGrid : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression Position;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Texts;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression XCount;

    public override object GetAnyResult(IExecutionContext context)
    {
        return UnityEngine.GUI.SelectionGrid(Position.GetResult<UnityEngine.Rect>(context), Selected.GetResult<System.Int32>(context), Texts.GetResult<System.String>(context), XCount.GetResult<System.Int32>(context));
    }
}
