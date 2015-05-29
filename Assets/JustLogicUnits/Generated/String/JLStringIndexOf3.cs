using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Index Of")]
[UnitFriendlyName("String.Index Of")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLStringIndexOf3 : JLExpression
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
        return opValue.IndexOf(Value.GetResult<System.String>(context), ComparisonType.GetResult<System.StringComparison>(context));
    }
}
