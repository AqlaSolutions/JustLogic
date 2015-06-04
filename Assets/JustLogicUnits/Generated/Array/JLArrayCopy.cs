using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Copy")]
[UnitFriendlyName("Array.Copy")]
public class JLArrayCopy : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression SourceArray;

    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression DestinationArray;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Length;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Array.Copy(SourceArray.GetResult<Array>(context), DestinationArray.GetResult<Array>(context), Length.GetResult<Int32>(context));
        return null;
    }
}
