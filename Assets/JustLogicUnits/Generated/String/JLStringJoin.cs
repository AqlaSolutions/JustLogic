using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Join")]
[UnitFriendlyName("String.Join")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringJoin : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression Separator;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.String.Join(Separator.GetResult<System.String>(context), Value.GetResult<System.String>(context));
    }
}
