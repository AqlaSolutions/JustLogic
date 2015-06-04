using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Index Of")]
[UnitFriendlyName("String.Index Of")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLStringIndexOf3 : JLExpression
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
        return opValue.IndexOf(Value.GetResult<String>(context), ComparisonType.GetResult<StringComparison>(context));
    }
}
