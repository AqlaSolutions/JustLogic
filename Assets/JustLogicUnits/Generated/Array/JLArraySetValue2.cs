using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Set Value")]
[UnitFriendlyName("Array.Set Value")]
public class JLArraySetValue2 : JLAction
{
    [Parameter(ExpressionType = typeof(Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(Int32))]
    public JLExpression Index;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        Array opValue = OperandValue.GetResult<Array>(context);
        opValue.SetValue(Value.GetResult<object>(context), Index.GetResult<Int32>(context));
        return null;
    }
}
