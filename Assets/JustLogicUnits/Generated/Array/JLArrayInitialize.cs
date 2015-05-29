using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Initialize")]
[UnitFriendlyName("Array.Initialize")]
public class JLArrayInitialize : JLAction
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        opValue.Initialize();
        return null;
    }
}
