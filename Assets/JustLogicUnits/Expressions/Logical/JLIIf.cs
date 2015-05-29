using System;
using System.Collections.Generic;
using JustLogic.Core;

[UnitFriendlyName("IIf")]
[UnitUsage(HideExpressionInActionsList = true)]
[UnitMenu("Branch/IIf")]
[UnitMenu("Logical/IIf")]
public class JLIIf : JLExpression
{
    [Parameter(ExpressionType = typeof(bool), DefaultUnitType = typeof(JLCompare))]
    public JLExpression Value;

    [Parameter]
    public JLExpression True;

    [Parameter]
    public JLExpression False;

    public override object GetAnyResult(IExecutionContext context)
    {
        if (Value.GetResult<bool>(context))
            return True.GetAnyResultSafe(context);

        return False.GetAnyResultSafe(context);
    }
}
