using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Trim End")]
[UnitFriendlyName("String.Trim End")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringTrimEnd : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Char))]
    public JLExpression[] TrimChars;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.TrimEnd(TrimChars.GetResult<System.Char>(context));
    }
}
