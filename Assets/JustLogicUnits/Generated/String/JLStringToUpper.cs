using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/To Upper")]
[UnitFriendlyName("String.To Upper")]
[UnitUsage(typeof(String), HideExpressionInActionsList = true)]
public class JLStringToUpper : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.ToUpper();
    }
}
