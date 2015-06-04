using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Set Value (multi indexed)")]
[UnitFriendlyName("Array.Set Value (multi indexed)")]
public class JLArraySetValue : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression[] Indices;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        opValue.SetValue(Value.GetResult<object>(context), Indices.GetResult<Int32>(context));
        return null;
    }
}
