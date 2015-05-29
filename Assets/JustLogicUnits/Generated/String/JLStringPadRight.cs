using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Pad Right")]
[UnitFriendlyName("String.Pad Right")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringPadRight : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression TotalWidth;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.PadRight(TotalWidth.GetResult<System.Int32>(context));
    }
}
