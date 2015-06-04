using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Value")]
[UnitFriendlyName("Array.Get Value")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayGetValue4 : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        return opValue.GetValue(Index.GetResult<Int32>(context));
    }
}
