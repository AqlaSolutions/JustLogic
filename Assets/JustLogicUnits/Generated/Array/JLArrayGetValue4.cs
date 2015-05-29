using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Value")]
[UnitFriendlyName("Array.Get Value")]
[UnitUsage(typeof(object), HideExpressionInActionsList = true)]
public class JLArrayGetValue4 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        return opValue.GetValue(Index.GetResult<System.Int32>(context));
    }
}
