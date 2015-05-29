using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Upper Bound")]
[UnitFriendlyName("Array.Get Upper Bound")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayGetUpperBound : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Dimension;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        return opValue.GetUpperBound(Dimension.GetResult<System.Int32>(context));
    }
}
