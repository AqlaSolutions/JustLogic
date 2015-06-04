using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Last Index Of")]
[UnitFriendlyName("String.Last Index Of")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLStringLastIndexOf6 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(StringComparison))]
    public JLExpression ComparisonType;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.LastIndexOf(Value.GetResult<String>(context), StartIndex.GetResult<Int32>(context), ComparisonType.GetResult<StringComparison>(context));
    }
}
