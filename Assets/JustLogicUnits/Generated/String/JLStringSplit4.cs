using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Split")]
[UnitFriendlyName("String.Split")]
[UnitUsage(typeof(System.String[]), HideExpressionInActionsList = true)]
public class JLStringSplit4 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression[] Separator;

    [Parameter(ExpressionType = typeof(System.StringSplitOptions))]
    public JLExpression Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Split(Separator.GetResult<System.String>(context), Options.GetResult<System.StringSplitOptions>(context));
    }
}
