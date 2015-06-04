using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("GUILayout/SelectionGrid")]
[UnitFriendlyName("GUILayout.SelectionGrid")]
[UnitUsage(typeof(System.Int32))]
public class JLGuiLayoutSelectionGrid : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Selected;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Texts;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression XCount;

    [Parameter(ExpressionType = typeof(GUILayoutOption))]
    public JLExpression[] Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        return GUILayout.SelectionGrid(Selected.GetResult<System.Int32>(context), Texts.GetResult<System.String>(context), XCount.GetResult<System.Int32>(context), Options.GetResult<GUILayoutOption>(context));
    }
}
