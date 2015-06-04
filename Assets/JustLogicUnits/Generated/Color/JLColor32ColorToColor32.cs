using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Color To Color32")]
[UnitFriendlyName("Color32.ColorToColor32")]
[UnitUsage(typeof(Color32), HideExpressionInActionsList = true)]
public class JLColor32ColorToColor32 : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression C;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (Color32)C.GetResult<Color>(context);
    }
}
