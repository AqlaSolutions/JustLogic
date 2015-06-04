using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Trim Start")]
[UnitFriendlyName("String.Trim Start")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringTrimStart : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Char))]
    public JLExpression[] TrimChars;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.TrimStart(TrimChars.GetResult<Char>(context));
    }
}
