using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Pad Left")]
[UnitFriendlyName("String.Pad Left")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringPadLeft : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression TotalWidth;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.PadLeft(TotalWidth.GetResult<Int32>(context));
    }
}
