using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Clone")]
[UnitFriendlyName("Array.Clone")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayClone : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        return opValue.Clone();
    }
}
