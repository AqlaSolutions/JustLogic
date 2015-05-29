using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Get G (Color32)")]
[UnitFriendlyName("Color32.Get G")]
[UnitUsage(typeof(System.Byte), HideExpressionInActionsList = true)]
public class JLColor32GetG : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color32))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Color32 opValue = OperandValue.GetResult<UnityEngine.Color32>(context);
        return opValue.g;
    }
}
