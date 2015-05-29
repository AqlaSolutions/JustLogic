using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/To Upper")]
[UnitFriendlyName("String.To Upper")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringToUpper : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.ToUpper();
    }
}
