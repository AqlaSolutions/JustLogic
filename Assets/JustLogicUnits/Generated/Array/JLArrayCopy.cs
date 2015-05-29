using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Copy")]
[UnitFriendlyName("Array.Copy")]
public class JLArrayCopy : JLAction
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression SourceArray;

    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression DestinationArray;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Length;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array.Copy(SourceArray.GetResult<System.Array>(context), DestinationArray.GetResult<System.Array>(context), Length.GetResult<System.Int32>(context));
        return null;
    }
}
