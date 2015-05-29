using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Value (multi indexed)")]
[UnitFriendlyName("Array.Get Value (multi indexed)")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayGetValue : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression[] Indices;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        return opValue.GetValue(Indices.GetResult<System.Int32>(context));
    }
}
