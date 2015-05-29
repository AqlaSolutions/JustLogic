using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Trim")]
[UnitFriendlyName("String.Trim")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringTrim : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Trim();
    }
}
