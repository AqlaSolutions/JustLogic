using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Index Of Any")]
[UnitFriendlyName("String.Index Of Any")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLStringIndexOfAny2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Char))]
    public JLExpression[] AnyOf;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression StartIndex;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.IndexOfAny(AnyOf.GetResult<System.Char>(context), StartIndex.GetResult<System.Int32>(context));
    }
}
