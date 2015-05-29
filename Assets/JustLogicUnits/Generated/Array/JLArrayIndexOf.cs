using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Index Of")]
[UnitFriendlyName("Array.Index Of")]
[UnitUsage(typeof(System.Int32), HideExpressionInActionsList = true)]
public class JLArrayIndexOf : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    public override object GetAnyResult(IExecutionContext context)
    {
        return System.Array.IndexOf(Array.GetResult<System.Array>(context), Value.GetResult<object>(context));
    }
}
