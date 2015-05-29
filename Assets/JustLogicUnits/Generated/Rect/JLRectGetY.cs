using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get Y")]
[UnitFriendlyName("Rect.Get Y")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetY : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        return opValue.y;
    }
}
