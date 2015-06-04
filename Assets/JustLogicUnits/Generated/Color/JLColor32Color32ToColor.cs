using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Color32 To Color")]
[UnitFriendlyName("Color32.Color32ToColor")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColor32Color32ToColor : JLExpression
{
    [Parameter(ExpressionType = typeof(Color32))]
    public JLExpression C;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (Color)C.GetResult<Color32>(context);
    }
}
