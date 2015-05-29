using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Color32 To Color")]
[UnitFriendlyName("Color32.Color32ToColor")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColor32Color32ToColor : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color32))]
    public JLExpression C;

    public override object GetAnyResult(IExecutionContext context)
    {
        return (UnityEngine.Color)C.GetResult<UnityEngine.Color32>(context);
    }
}
