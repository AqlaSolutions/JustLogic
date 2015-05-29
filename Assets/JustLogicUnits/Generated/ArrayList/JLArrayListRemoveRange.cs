using JustLogic.Core;
using System.Collections.Generic;
using System.Collections;

[UnitMenu("ArrayList/Remove Range")]
[UnitFriendlyName("ArrayList.Remove Range")]
public class JLArrayListRemoveRange : JLAction
{
    [Parameter(ExpressionType = typeof(System.Collections.ArrayList))]
    public JLExpression OperandValue;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Index;

    [Parameter(ExpressionType = typeof(System.Int32))]
    public JLExpression Count;

    protected override IEnumerator<YieldMode> OnExecute(IExecutionContext context)
    {
        System.Collections.ArrayList opValue = OperandValue.GetResult<System.Collections.ArrayList>(context);
        opValue.RemoveRange(Index.GetResult<System.Int32>(context), Count.GetResult<System.Int32>(context));
        return null;
    }
}
