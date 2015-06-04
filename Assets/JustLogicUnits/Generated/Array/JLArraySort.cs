using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Sort")]
[UnitFriendlyName("Array.Sort")]
[UnitUsage(typeof(Array))]
public class JLArraySort : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Array;

    public override object GetAnyResult(IExecutionContext context)
    {
        var r = Array.GetResult<Array>(context);
        System.Array.Sort(r);
        return r;
    }
}
