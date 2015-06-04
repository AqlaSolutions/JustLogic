using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Sort With Keys")]
[UnitFriendlyName("Array.Sort With Keys")]
[UnitUsage(typeof(Array))]
public class JLArraySort2 : JLExpression
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Keys;

    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Items;

    public override object GetAnyResult(IExecutionContext context)
    {
        var r = Items.GetResult<Array>(context);
        Array.Sort(Keys.GetResult<Array>(context), r);
        return r;
    }
}
