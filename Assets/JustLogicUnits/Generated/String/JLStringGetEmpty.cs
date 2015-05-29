using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Get Empty")]
[UnitFriendlyName("String.Get Empty")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringGetEmpty : JLExpression
{
    public override object GetAnyResult(IExecutionContext context)
    {
        return System.String.Empty;
    }
}
