using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Starts With")]
[UnitFriendlyName("String.Starts With")]
[UnitUsage(typeof(System.Boolean), HideExpressionInActionsList = true)]
public class JLStringStartsWith2 : JLExpression
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
        return opValue.StartsWith(Value.GetResult<System.String>(context), ComparisonType.GetResult<System.StringComparison>(context));
    }
}
