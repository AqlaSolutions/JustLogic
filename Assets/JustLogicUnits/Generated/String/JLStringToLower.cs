using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/To Lower")]
[UnitFriendlyName("String.To Lower")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringToLower : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.ToLower();
    }
}
