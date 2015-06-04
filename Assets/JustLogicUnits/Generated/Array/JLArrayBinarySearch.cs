using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Binary Search")]
[UnitFriendlyName("Array.Binary Search")]
[UnitUsage(typeof(Int32), HideExpressionInActionsList = true)]
public class JLArrayBinarySearch : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.Array.BinarySearch(Array.GetResult<Array>(context), Value.GetResult<object>(context));
    }
}
