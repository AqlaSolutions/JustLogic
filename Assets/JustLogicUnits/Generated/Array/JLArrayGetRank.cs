using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Get Rank")]
[UnitFriendlyName("Array.Get Rank")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayGetRank : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    public override object GetAnyResult(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        return opValue.Rank;
    }
}
