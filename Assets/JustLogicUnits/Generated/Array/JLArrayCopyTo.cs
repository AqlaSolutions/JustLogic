using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Copy To")]
[UnitFriendlyName("Array.Copy To")]
public class JLArrayCopyTo : JLAction
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression Array;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        opValue.CopyTo(Array.GetResult<System.Array>(context), Index.GetResult<System.Int32>(context));
        return null;
    }
}
