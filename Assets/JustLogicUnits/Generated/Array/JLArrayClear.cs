using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Clear")]
[UnitFriendlyName("Array.Clear")]
public class JLArrayClear : JLAction
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Length;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array.Clear(Array.GetResult<System.Array>(context), Index.GetResult<System.Int32>(context), Length.GetResult<System.Int32>(context));
        return null;
    }
}
