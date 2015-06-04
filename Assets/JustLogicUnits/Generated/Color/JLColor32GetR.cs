using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get R (Color32)")]
[UnitFriendlyName("Color32.Get R")]
[UnitUsage(typeof(System.Byte), HideExpressionInActionsList = true)]
public class JLColor32GetR : JLExpression
{
    [Parameter(ExpressionType = typeof(Color32))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color32 opValue = OperandValue.GetResult<Color32>(context);
        return opValue.r;
    }
}
