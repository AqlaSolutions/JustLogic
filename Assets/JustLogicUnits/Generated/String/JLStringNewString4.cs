using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/From Char")]
[UnitFriendlyName("String.From Char")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringNewString4 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Char))]
    public JLExpression C;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    public override object GetAnyResult(IExecutionContext context)
    {
        return new System.String(C.GetResult<System.Char>(context), Count.GetResult<System.Int32>(context));
    }
}
