using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Value (multi indexed)")]
[UnitFriendlyName("Array.Get Value (multi indexed)")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayGetValue : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression[] Indices;

    public override object GetAnyResult(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        return opValue.GetValue(Indices.GetResult<Int32>(context));
    }
}
