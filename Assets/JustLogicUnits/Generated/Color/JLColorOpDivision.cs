using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Division")]
[UnitFriendlyName("Color.Op Division")]
[UnitUsage(typeof(Color), HideExpressionInActionsList = true)]
public class JLColorOpDivision : JLExpression
{
    [Parameter(ExpressionType = typeof(Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<Color>(context) / B.GetResult<System.Single>(context);
    }
}
