using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Concat")]
[UnitFriendlyName("String.Concat")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringConcat3 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Values;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.String.Concat(Values.GetResult<System.String>(context));
    }
}
