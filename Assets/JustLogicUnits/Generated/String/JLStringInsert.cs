using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Insert")]
[UnitFriendlyName("String.Insert")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringInsert : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Insert(StartIndex.GetResult<System.Int32>(context), Value.GetResult<System.String>(context));
    }
}
