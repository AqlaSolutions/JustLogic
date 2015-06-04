using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/From Char")]
[UnitFriendlyName("String.From Char")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringNewString4 : JLExpression
{
    [Parameter(ExpressionType = typeof(Char))]
    public JLExpression C;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new String(C.GetResult<Char>(context), Count.GetResult<Int32>(context));
    }
}
