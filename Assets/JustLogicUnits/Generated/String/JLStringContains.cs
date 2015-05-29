using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Contains")]
[UnitFriendlyName("String.Contains")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLStringContains : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Contains(Value.GetResult<System.String>(context));
    }
}
