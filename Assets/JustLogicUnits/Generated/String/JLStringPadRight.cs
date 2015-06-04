using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Pad Right")]
[UnitFriendlyName("String.Pad Right")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringPadRight : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression TotalWidth;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.PadRight(TotalWidth.GetResult<Int32>(context));
    }
}
