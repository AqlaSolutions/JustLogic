using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Subtraction")]
[UnitFriendlyName("Color.Op Subtraction")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorOpSubtraction : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<UnityEngine.Color>(context) - B.GetResult<UnityEngine.Color>(context);
    }
}
