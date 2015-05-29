using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Ends With")]
[UnitFriendlyName("String.Ends With")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLStringEndsWith2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.StringComparison))]
    public JLExpression ComparisonType;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.EndsWith(Value.GetResult<System.String>(context), ComparisonType.GetResult<System.StringComparison>(context));
    }
}
