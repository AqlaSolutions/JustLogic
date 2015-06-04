using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/To Lower")]
[UnitFriendlyName("String.To Lower")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringToLower : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.ToLower();
    }
}
