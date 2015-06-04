using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Split")]
[UnitFriendlyName("String.Split")]
[UnitUsage(typeof(String[]), HideExpressionInActionsList = true)]
public class JLStringSplit4 : JLExpression
{
    [Parameter(ExpressionType = typeof(String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(String))]
    public JLExpression[] Separator;

    [Parameter(ExpressionType = typeof(StringSplitOptions))]
    public JLExpression Options;

    public override object GetAnyResult(IExecutionContext context)
    {
        String opValue = OperandValue.GetResult<String>(context);
        return opValue.Split(Separator.GetResult<String>(context), Options.GetResult<StringSplitOptions>(context));
    }
}
