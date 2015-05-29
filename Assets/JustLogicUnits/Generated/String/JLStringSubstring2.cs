using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("String/Substring")]
[UnitFriendlyName("String.Substring")]
[UnitUsage(typeof(System.String), HideExpressionInActionsList = true)]
public class JLStringSubstring2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.String))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression StartIndex;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Length;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.String opValue = OperandValue.GetResult<System.String>(context);
        return opValue.Substring(StartIndex.GetResult<System.Int32>(context), Length.GetResult<System.Int32>(context));
    }
}
