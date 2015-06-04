using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Initialize")]
[UnitFriendlyName("Array.Initialize")]
public class JLArrayInitialize : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        opValue.Initialize();
        return null;
    }
}
