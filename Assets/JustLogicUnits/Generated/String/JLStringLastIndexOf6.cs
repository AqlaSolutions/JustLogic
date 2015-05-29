using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Last Index Of")]
[UnitFriendlyName("String.Last Index Of")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLStringLastIndexOf6 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(System.StringComparison))]
    public JLExpression ComparisonType;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.LastIndexOf(Value.GetResult<System.String>(context), StartIndex.GetResult<System.Int32>(context), ComparisonType.GetResult<System.StringComparison>(context));
    }
}
