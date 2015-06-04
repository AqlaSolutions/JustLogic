using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Clone")]
[UnitFriendlyName("Array.Clone")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayClone : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        return opValue.Clone();
    }
}
