using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Upper Bound")]
[UnitFriendlyName("Array.Get Upper Bound")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLArrayGetUpperBound : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Dimension;

    public override object GetAnyResult(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        return opValue.GetUpperBound(Dimension.GetResult<Int32>(context));
    }
}
