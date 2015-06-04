using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Subtraction")]
[UnitFriendlyName("Color.Op Subtraction")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorOpSubtraction : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Color>(context) - B.GetResult<Color>(context);
    }
}
