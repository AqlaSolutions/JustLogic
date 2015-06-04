using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Copy To")]
[UnitFriendlyName("Array.Copy To")]
public class JLArrayCopyTo : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Index;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        opValue.CopyTo(Array.GetResult<Array>(context), Index.GetResult<Int32>(context));
        return null;
    }
}
