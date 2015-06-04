using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Index Of Any")]
[UnitFriendlyName("String.Index Of Any")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLStringIndexOfAny2 : JLExpression
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
        return opValue.IndexOfAny(AnyOf.GetResult<Char>(context), StartIndex.GetResult<Int32>(context));
    }
}
