using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Addition")]
[UnitFriendlyName("Color.Op Addition")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorOpAddition : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<UnityEngine.Color>(context) + B.GetResult<UnityEngine.Color>(context);
    }
}
