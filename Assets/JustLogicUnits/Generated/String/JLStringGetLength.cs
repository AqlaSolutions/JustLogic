using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Get Length")]
[UnitFriendlyName("String.Get Length")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLStringGetLength : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Length;
    }
}
