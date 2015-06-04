using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Replace")]
[UnitFriendlyName("String.Replace")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringReplace2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OldValue;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression NewValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Replace(OldValue.GetResult<String>(context), NewValue.GetResult<String>(context));
    }
}
