using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Ends With")]
[UnitFriendlyName("String.Ends With")]
[UnitUsage(typeof(Boolean), HideExpressionInActionsList = true)]
public class JLStringEndsWith2 : JLExpression
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
        return opValue.EndsWith(Value.GetResult<String>(context), ComparisonType.GetResult<StringComparison>(context));
    }
}
