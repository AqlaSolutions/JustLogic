using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Trim End")]
[UnitFriendlyName("String.Trim End")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringTrimEnd : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Char))]
    public JLExpression[] TrimChars;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.TrimEnd(TrimChars.GetResult<Char>(context));
    }
}
