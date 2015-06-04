using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Lower Bound")]
[UnitFriendlyName("Array.Get Lower Bound")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLArrayGetLowerBound : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Dimension;

    public override object GetAnyResult(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        return opValue.GetLowerBound(Dimension.GetResult<Int32>(context));
    }
}
