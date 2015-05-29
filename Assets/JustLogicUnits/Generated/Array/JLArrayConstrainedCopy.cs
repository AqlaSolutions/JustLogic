using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Constrained Copy")]
[UnitFriendlyName("Array.Constrained Copy")]
public class JLArrayConstrainedCopy : JLAction
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression SourceArray;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression SourceIndex;

    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression DestinationArray;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression DestinationIndex;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Length;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array.ConstrainedCopy(SourceArray.GetResult<System.Array>(context), SourceIndex.GetResult<System.Int32>(context), DestinationArray.GetResult<System.Array>(context), DestinationIndex.GetResult<System.Int32>(context), Length.GetResult<System.Int32>(context));
        return null;
    }
}
