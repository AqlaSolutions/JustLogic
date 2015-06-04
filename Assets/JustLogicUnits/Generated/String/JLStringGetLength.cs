using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Get Length")]
[UnitFriendlyName("String.Get Length")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLStringGetLength : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Length;
    }
}
