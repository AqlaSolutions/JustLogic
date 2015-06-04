using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Last Index Of Any")]
[UnitFriendlyName("String.Last Index Of Any")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLStringLastIndexOfAny2 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Char))]
    public JLExpression[] AnyOf;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression StartIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.LastIndexOfAny(AnyOf.GetResult<Char>(context), StartIndex.GetResult<Int32>(context));
    }
}
