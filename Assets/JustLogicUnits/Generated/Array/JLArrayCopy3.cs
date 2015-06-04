using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Copy Advanced")]
[UnitFriendlyName("Array.Copy Advanced")]
public class JLArrayCopy3 : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression SourceArray;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression SourceIndex;

    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression DestinationArray;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression DestinationIndex;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Length;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Array.Copy(SourceArray.GetResult<Array>(context), SourceIndex.GetResult<Int32>(context), DestinationArray.GetResult<Array>(context), DestinationIndex.GetResult<Int32>(context), Length.GetResult<Int32>(context));
        return null;
    }
}
