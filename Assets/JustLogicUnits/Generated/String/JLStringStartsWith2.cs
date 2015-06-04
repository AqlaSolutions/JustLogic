using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Starts With")]
[UnitFriendlyName("String.Starts With")]
[UnitUsage(typeof(Boolean), HideExpressionInActionsList = true)]
public class JLStringStartsWith2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(StringComparison))]
    public JLExpression ComparisonType;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.StartsWith(Value.GetResult<String>(context), ComparisonType.GetResult<StringComparison>(context));
    }
}
