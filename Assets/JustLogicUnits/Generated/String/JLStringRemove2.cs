using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Remove")]
[UnitFriendlyName("String.Remove")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringRemove2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Remove(StartIndex.GetResult<System.Int32>(context), Count.GetResult<System.Int32>(context));
    }
}
