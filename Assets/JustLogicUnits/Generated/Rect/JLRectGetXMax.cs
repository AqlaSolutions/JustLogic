using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get XMax")]
[UnitFriendlyName("Rect.Get XMax")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetXMax : JLExpression
{
    [Parameter(ExpressionType = typeof(Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Rect opValue = OperandValue.GetResult<Rect>(context);
        return opValue.xMax;
    }
}
