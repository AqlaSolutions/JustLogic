using JustLogic.Core;
using System.Collections.Generic;
using System;

[UnitMenu("Array/Set Value")]
[UnitFriendlyName("Array.Set Value")]
public class JLArraySetValue2 : JLAction
{
    [Parameter(ExpressionType = typeof(System.Array))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(object))]
    public JLExpression Value;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Array opValue = OperandValue.GetResult<System.Array>(context);
        opValue.SetValue(Value.GetResult<object>(context), Index.GetResult<System.Int32>(context));
        return null;
    }
}
