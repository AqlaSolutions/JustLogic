using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Multiply")]
[UnitFriendlyName("Color.Op Multiply")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorOpMultiply : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Color>(context) * B.GetResult<Color>(context);
    }
}
