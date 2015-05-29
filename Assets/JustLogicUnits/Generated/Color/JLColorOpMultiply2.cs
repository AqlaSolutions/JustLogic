using JustLogic.Core;
using System.Collections.Generic;
using UnityEngine;

[UnitMenu("Color/Op Multiply")]
[UnitFriendlyName("Color.Op Multiply")]
[UnitUsage(typeof(UnityEngine.Color), HideExpressionInActionsList = true)]
public class JLColorOpMultiply2 : JLExpression
{
    [Parameter(ExpressionType = typeof(UnityEngine.Color))]
    public JLExpression A;

    [Parameter(ExpressionType = typeof(System.Single))]
    public JLExpression B;

    public override object GetAnyResult(IExecutionContext context)
    {
        return A.GetResult<UnityEngine.Color>(context) * B.GetResult<System.Single>(context);
    }
}
