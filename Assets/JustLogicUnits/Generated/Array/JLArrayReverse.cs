using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Reverse")]
[UnitFriendlyName("Array.Reverse")]
[UnitUsage(typeof(Array))]
public class JLArrayReverse : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Array;

    public override object GetAnyResult(IExecutionContext context)
    {
        var r = Array.GetResult<System.Array>(context);
        System.Array.Reverse(r);
        return r;
    }
}
