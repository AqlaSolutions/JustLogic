using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Substring")]
[UnitFriendlyName("String.Substring")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringSubstring2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Length;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Substring(StartIndex.GetResult<Int32>(context), Length.GetResult<Int32>(context));
    }
}
