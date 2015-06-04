using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Remove")]
[UnitFriendlyName("String.Remove")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringRemove2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Remove(StartIndex.GetResult<Int32>(context), Count.GetResult<Int32>(context));
    }
}
