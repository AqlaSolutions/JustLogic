using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Concat")]
[UnitFriendlyName("String.Concat")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringConcat3 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression[] Values;

    public override object GetAnyResult(IExecutionContext context)
    {
        return String.Concat(Values.GetResult<String>(context));
    }
}
