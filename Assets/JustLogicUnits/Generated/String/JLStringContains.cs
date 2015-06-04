using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Contains")]
[UnitFriendlyName("String.Contains")]
[UnitUsage(typeof(Boolean), HideExpressionInActionsList = true)]
public class JLStringContains : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Contains(Value.GetResult<String>(context));
    }
}
