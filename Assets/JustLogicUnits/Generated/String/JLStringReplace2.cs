using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Replace")]
[UnitFriendlyName("String.Replace")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringReplace2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OldValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression NewValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Replace(OldValue.GetResult<System.String>(context), NewValue.GetResult<System.String>(context));
    }
}
