using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Addition")]
[UnitFriendlyName("Color.Op Addition")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorOpAddition : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Color>(context) + B.GetResult<Color>(context);
    }
}
