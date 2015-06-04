using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Clear")]
[UnitFriendlyName("Array.Clear")]
public class JLArrayClear : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Length;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array.Clear(Array.GetResult<Array>(context), Index.GetResult<Int32>(context), Length.GetResult<Int32>(context));
        return null;
    }
}
