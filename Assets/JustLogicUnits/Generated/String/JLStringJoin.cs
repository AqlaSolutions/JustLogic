using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Join")]
[UnitFriendlyName("String.Join")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringJoin : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression Separator;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression[] Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return String.Join(Separator.GetResult<String>(context), Value.GetResult<String>(context));
    }
}
