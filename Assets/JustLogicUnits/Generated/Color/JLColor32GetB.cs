using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get B (Color32)")]
[UnitFriendlyName("Color32.Get B")]
[UnitUsage(typeof(System.Byte), HideExpressionInActionsList = true)]
public class JLColor32GetB : JLExpression
{
    [Parameter(ExpressionType = typeof(Color32))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Color32 opValue = OperandValue.GetResult<Color32>(context);
        return opValue.b;
    }
}
