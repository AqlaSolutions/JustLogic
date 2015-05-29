using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Rect/Get XMin")]
[UnitFriendlyName("Rect.Get XMin")]
[UnitUsage(typeof(System.Single), HideExpressionInActionsList = true)]
public class JLRectGetXMin : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Rect))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        UnityEngine.Rect opValue = OperandValue.GetResult<UnityEngine.Rect>(context);
        return opValue.xMin;
    }
}
