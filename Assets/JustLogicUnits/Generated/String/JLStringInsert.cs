using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Insert")]
[UnitFriendlyName("String.Insert")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringInsert : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Insert(StartIndex.GetResult<Int32>(context), Value.GetResult<String>(context));
    }
}
