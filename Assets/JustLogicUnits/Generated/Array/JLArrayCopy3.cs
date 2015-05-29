using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Copy Advanced")]
[UnitFriendlyName("Array.Copy Advanced")]
public class JLArrayCopy3 : JLAction
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
        System.Array.Copy(SourceArray.GetResult<System.Array>(context), SourceIndex.GetResult<System.Int32>(context), DestinationArray.GetResult<System.Array>(context), DestinationIndex.GetResult<System.Int32>(context), Length.GetResult<System.Int32>(context));
        return null;
    }
}
