using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Trim Start")]
[UnitFriendlyName("String.Trim Start")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringTrimStart : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Char))]
    public JLExpression[] TrimChars;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.TrimStart(TrimChars.GetResult<System.Char>(context));
    }
}
