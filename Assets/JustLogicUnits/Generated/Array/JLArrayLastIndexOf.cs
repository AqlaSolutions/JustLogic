using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Last Index Of")]
[UnitFriendlyName("Array.Last Index Of")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLArrayLastIndexOf : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.Array.LastIndexOf(Array.GetResult<Array>(context), Value.GetResult<object>(context));
    }
}
