using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Trim")]
[UnitFriendlyName("String.Trim")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringTrim : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Trim();
    }
}
