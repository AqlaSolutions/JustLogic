using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Sort With Keys")]
[UnitFriendlyName("Array.Sort With Keys")]
[UnitUsage(typeof(Array))]
public class JLArraySort2 : JLExpression
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Keys;

    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Items;

    public override object GetAnyResult(IExecutionContext context)
    {
        var r = Items.GetResult<System.Array>(context);
        System.Array.Sort(Keys.GetResult<System.Array>(context), r);
        return r;
    }
}
